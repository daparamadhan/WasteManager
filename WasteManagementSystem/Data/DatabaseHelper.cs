using MongoDB.Driver;
using WasteManagementSystem.Models;
using Microsoft.Extensions.Configuration;

namespace WasteManagementSystem.Data
{
    public static class DatabaseHelper
    {
        private static string? _connectionString;
        private static string DatabaseName = "WasteManagement";

        private static IMongoDatabase? _database;

        public static void InitializeDatabase()
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            _connectionString = config["MongoDB:ConnectionString"];

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "MongoDB connection string not found in appsettings.json. " +
                    "Please ensure MongoDB:ConnectionString is configured.");
            }

            try
            {
                var client = new MongoClient(_connectionString);
                _database = client.GetDatabase(DatabaseName);

                // Verify connection
                var adminDb = client.GetDatabase("admin");
                adminDb.RunCommand<dynamic>(new MongoDB.Bson.BsonDocument("ping", 1));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to connect to MongoDB. Please verify your connection string in appsettings.json.",
                    ex);
            }
            
            // Seed Admin
            if (Users.CountDocuments(u => u.Username == "admin") == 0)
            {
                Users.InsertOne(new User {
                    Username = "admin",
                    PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", // SHA256("admin")
                    Role = "Admin",
                    FullName = "Administrator",
                    Address = "HQ",
                    PhoneNumber = "08123456789"
                });
            }

            // Seed Sample Waste Data if no entries have coordinates (so Maps show something)
            if (WasteEntries.CountDocuments(w => w.Latitude != 0) == 0)
            {
                var admin = Users.Find(u => u.Username == "admin").FirstOrDefault();
                string adminId = admin?.Id ?? "";

                WasteEntries.InsertMany(new[] {
                    new WasteEntry {
                        UserId = adminId,
                        WasteType = "B3",
                        Weight = 10.5,
                        Location = "TPPAS Sarimukti - Cipatat, Kab. Bandung Barat",
                        Description = "Limbah medis terkumpul",
                        Status = "Pending",
                        Latitude = -6.8373,
                        Longitude = 107.3364,
                        CreatedAt = DateTime.Now.AddDays(-1)
                    },
                    new WasteEntry {
                        UserId = adminId,
                        WasteType = "Organik",
                        Weight = 25.0,
                        Location = "TPPAS Legok Nangka - Nagreg, Kab. Bandung",
                        Description = "Sisa makanan pasar",
                        Status = "Completed",
                        Latitude = -7.0197,
                        Longitude = 107.8285,
                        CreatedAt = DateTime.Now.AddDays(-2),
                        UpdatedAt = DateTime.Now.AddMinutes(-30)
                    },
                    new WasteEntry {
                        UserId = adminId,
                        WasteType = "Anorganik",
                        Weight = 15.2,
                        Location = "TPPAS Lulut Nambo - Klapanunggal, Kab. Bogor",
                        Description = "Botol plastik kemasan",
                        Status = "Pending",
                        Latitude = -6.4912,
                        Longitude = 106.9178,
                        CreatedAt = DateTime.Now
                    }
                });
            }
        }

        public static IMongoCollection<User> Users
        {
            get
            {
                if (_database == null)
                {
                    throw new InvalidOperationException(
                        "Database has not been initialized. Call InitializeDatabase() first.");
                }
                return _database.GetCollection<User>("Users");
            }
        }

        public static IMongoCollection<WasteEntry> WasteEntries
        {
            get
            {
                if (_database == null)
                {
                    throw new InvalidOperationException(
                        "Database has not been initialized. Call InitializeDatabase() first.");
                }
                return _database.GetCollection<WasteEntry>("WasteEntries");
            }
        }
    }
}

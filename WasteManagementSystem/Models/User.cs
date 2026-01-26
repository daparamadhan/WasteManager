using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WasteManagementSystem.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin", "Petugas", "Masyarakat"
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

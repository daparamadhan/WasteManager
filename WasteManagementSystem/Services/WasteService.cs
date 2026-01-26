using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WasteManagementSystem.Data;
using WasteManagementSystem.Models;

namespace WasteManagementSystem.Services
{
    public class WasteService
    {
        public IEnumerable<WasteEntry> GetPending()
        {
            return DatabaseHelper.WasteEntries.Find(w => w.Status != "Completed")
                                              .SortByDescending(w => w.CreatedAt)
                                              .ToList();
        }

        public IEnumerable<WasteEntry> GetPendingByUserId(string userId)
        {
            return DatabaseHelper.WasteEntries.Find(w => w.UserId == userId && w.Status != "Completed")
                                              .SortByDescending(w => w.CreatedAt)
                                              .ToList();
        }

        public IEnumerable<WasteEntry> GetAll()
        {
            return DatabaseHelper.WasteEntries.Find(_ => true)
                                              .SortByDescending(w => w.CreatedAt)
                                              .ToList();
        }

        public IEnumerable<WasteEntry> GetByUserId(string userId)
        {
            return DatabaseHelper.WasteEntries.Find(w => w.UserId == userId)
                                              .SortByDescending(w => w.CreatedAt)
                                              .ToList();
        }

        public void Add(WasteEntry entry)
        {
            try
            {
                // ObjectId is auto-generated if null, but we can also set it explicitly if needed.
                // InsertOne handles it.
                DatabaseHelper.WasteEntries.InsertOne(entry);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting WasteEntry: " + ex.Message, ex);
            }
        }

        public void UpdateStatus(string id, string status)
        {
            var update = Builders<WasteEntry>.Update.Set(w => w.Status, status)
                                                    .Set(w => w.UpdatedAt, DateTime.Now);
            DatabaseHelper.WasteEntries.UpdateOne(w => w.Id == id, update);
        }

        public void Update(WasteEntry entry)
        {
            var filter = Builders<WasteEntry>.Filter.Eq(w => w.Id, entry.Id);
            DatabaseHelper.WasteEntries.ReplaceOne(filter, entry);
        }

        public Dictionary<string, double> GetDailyStats()
        {
            var last7Days = DateTime.Now.Date.AddDays(-6);
            var entries = DatabaseHelper.WasteEntries.Find(w => w.CreatedAt >= last7Days).ToList();

            var stats = new Dictionary<string, double>();
            for (int i = 6; i >= 0; i--)
            {
                string date = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd");
                stats[date] = 0;
            }

            foreach (var entry in entries)
            {
                string date = entry.CreatedAt.ToString("yyyy-MM-dd");
                if (stats.ContainsKey(date))
                {
                    stats[date] += entry.Weight;
                }
            }

            return stats;
        }

        public Dictionary<string, double> GetWasteByType()
        {
            var allEntries = DatabaseHelper.WasteEntries.Find(_ => true).ToList();
            var stats = new Dictionary<string, double>
            {
                { "Organik", 0 },
                { "Anorganik", 0 },
                { "B3", 0 }
            };

            foreach (var entry in allEntries)
            {
                if (stats.ContainsKey(entry.WasteType))
                {
                    stats[entry.WasteType] += entry.Weight;
                }
            }

            return stats;
        }

        public Dictionary<string, double> GetWasteByLocation()
        {
            var allEntries = DatabaseHelper.WasteEntries.Find(_ => true).ToList();
            var stats = new Dictionary<string, double>();

            foreach (var entry in allEntries)
            {
                if (!string.IsNullOrEmpty(entry.Location))
                {
                    if (!stats.ContainsKey(entry.Location))
                        stats[entry.Location] = 0;
                    
                    stats[entry.Location] += entry.Weight;
                }
            }

            return stats;
        }

        public void Delete(string id)
        {
            DatabaseHelper.WasteEntries.DeleteOne(w => w.Id == id);
        }
    }
}

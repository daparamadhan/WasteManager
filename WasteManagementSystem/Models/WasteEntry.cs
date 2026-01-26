using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WasteManagementSystem.Models
{
    public class WasteEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } // Foreign Key to User

        public string WasteType { get; set; } // "Organik", "Anorganik", "B3"
        public double Weight { get; set; } // in kg
        public string Location { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending", "PickedUp", "Completed"
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

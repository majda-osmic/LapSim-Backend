using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LapSimBackend.Models
{
    public class Budget
    {
        public int Units { get; set; }

        [BsonElement("OrderDate")]
        public DateTime Ordered { get; set; }

        [BsonElement("ExpiryDate")]
        public DateTime Expires { get; set; }
    }
}

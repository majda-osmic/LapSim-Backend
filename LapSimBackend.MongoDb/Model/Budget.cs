using LapSimBackend.Data.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LapSimBackend.MongoDb.Model
{
    public class Budget : IBudget
    {
        public int Units { get; set; }

        [BsonElement("OrderDate")]
        public DateTime Ordered { get; set; }

        [BsonElement("ExpiryDate")]
        public DateTime Expires { get; set; }
    }
}

using LapSimBackend.Data.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace LapSimBackend.MongoDb.Model
{
    public class SoftwarePackage
    {
        [BsonElement("Timestamp")]
        public DateTime TimeStamp { get; set; }
        public IEnumerable<Software> Software { get; set; }
    }
}

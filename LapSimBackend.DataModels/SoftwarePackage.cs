using LapSimBackend.Data.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace LapSimBackend.DataModels
{
    public class SoftwarePackage : ISoftwarePackage
    {
        [BsonElement("Timestamp")]
        public DateTime TimeStamp { get; set; }
        public IEnumerable<ISoftware> Software { get; set; }
    }
}

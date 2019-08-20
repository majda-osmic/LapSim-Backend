using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Models
{
    public class SoftwarePackage
    {
        [BsonElement("Timestamp")]
        public DateTime TimeStamp { get; set; }
        public IEnumerable<Software> Software { get; set; }
    }
}

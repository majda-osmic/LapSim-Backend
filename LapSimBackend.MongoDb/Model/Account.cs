using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LapSimBackend.MongoDb.Model
{
    public class Account : IAccount
    {
        public string UniqueName { get; set; }
        public string Name { get; set; }

        [BsonElement("CPUS")]
        public int CPUs { get; set; }

    }
}

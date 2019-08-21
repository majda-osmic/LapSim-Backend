using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace LapSimBackend.DataModels
{
    public class Account : IAccount
    {
        public string UniqueName { get; set; }
        public string Name { get; set; }

        [BsonElement("CPUS")]
        public int CPUs { get; set; }
    }
}

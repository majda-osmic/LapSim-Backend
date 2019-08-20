using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace LapSimBackend.Models
{
    public class Account
    {
        public string UniqueName { get; set; }
        public string Name { get; set; }

        [BsonElement("CPUS")]
        public int CPUs { get; set; }
    }
}

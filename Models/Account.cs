using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace LapSimBackend.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }

        [BsonElement("Cpu")]
        public int CPUs { get; set; }
    }
}

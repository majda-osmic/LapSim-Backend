using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LapSimBackend.MongoDb.Model
{
    public class ProjectLeader
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("teams")]
        public IEnumerable<object> Teams { get; set; }
    }
}

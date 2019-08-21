using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LapSimBackend.DataModels
{
    public class ProjectLeader : IProjectLeader
    {
        [BsonId]
        [JsonProperty(PropertyName = "userName")]
        public string Id { get; set; }

        [BsonElement("teams")]
        public IEnumerable<object> Teams { get; set; }
    }
}

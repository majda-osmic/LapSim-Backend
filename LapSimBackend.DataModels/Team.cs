using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace LapSimBackend.DataModels
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public IEnumerable<Budget> Budgets { get; set; }

        [BsonElement("SoftwarePackages")]
        public IEnumerable<SoftwarePackage> Pacakges { get; set; }

    }
}

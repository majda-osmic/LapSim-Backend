using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Models
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

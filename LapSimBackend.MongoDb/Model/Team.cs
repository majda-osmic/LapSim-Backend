using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace LapSimBackend.MongoDb.Model
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public IEnumerable<Budget> Budgets { get; set; }




    }
}

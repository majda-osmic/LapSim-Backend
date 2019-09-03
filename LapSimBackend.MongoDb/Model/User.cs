using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LapSimBackend.MongoDb.Model
{
    public class User : IUser
    {
        [BsonId]
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}

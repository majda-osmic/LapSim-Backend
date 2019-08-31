using LapSimBackend.Data.Interfaces;
using LapSimBackend.Data.Interfaces.Implementations;
using LapSimBackend.MongoDb.Model;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Utils.Exceptions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


namespace LapSimBackend.MongoDb.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _userCollection = database.GetCollection<User>(settings.UserCollectionName);
        }

        public IAuthenticatedUser Authenticate(string userName, string password)
        {
            var user = _userCollection.Find(dbUser => dbUser.Username == userName).FirstOrDefault();
            if (user == null)
                throw new KeyNotFoundException($"User {userName} does not exist");
            
            if(!PasswordsMatch(password, user))
                return null;


            return new AuthenticatedUser()
            {
                Username = user.Username,
                Role = UserRole.FromString(user.Role)
            };
        }

        public IUser Create(string userName, string password)
        {
            //TODO: validate strings

            if (_userCollection.Find(item => item.Username.Equals(userName)).Any())
            {
                throw new UserAlreadyExistsException(userName);
            }

            var salt = HashHelper.GenerateSalt();
            var hash = HashHelper.ComputeHash(password, salt);

            var user = new User()
            {
                Username = userName,
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = Convert.ToBase64String(salt)
            };

            _userCollection.InsertOne(user);

            return user;
        }


        private bool PasswordsMatch(string password, User user)
        {
            var savedHash = HashHelper.ComputeHash(password, Convert.FromBase64String(user.PasswordSalt));
            return Convert.ToBase64String(savedHash).Equals(user.PasswordHash);
        }
    }
}

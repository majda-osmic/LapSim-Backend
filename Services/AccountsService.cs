using LapSimBackend.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Services
{
    public class AccountsService
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountsService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _accounts = database.GetCollection<Account>(settings.AccountsCollectionName);
        }

        public List<Account> Get() =>
            _accounts.Find(Account => true).ToList();

        public Account Get(string id) =>
            _accounts.Find(Account => Account.Id == id).FirstOrDefault();

        public Account Create(Account Account)
        {
            _accounts.InsertOne(Account);
            return Account;
        }

        public void Update(string id, Account accountIn) =>
            _accounts.ReplaceOne(Account => Account.Id == id, accountIn);

        public void Remove(Account accountIn) =>
            _accounts.DeleteOne(Account => Account.Id == accountIn.Id);

        public void Remove(string id) =>
            _accounts.DeleteOne(Account => Account.Id == id);
    }
}


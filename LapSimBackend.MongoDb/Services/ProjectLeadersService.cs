using LapSimBackend.Data.Interfaces;
using LapSimBackend.MongoDb.Model;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.MongoDb.Services
{


    public class ProjectLeadersService : IProjectLeadersService
    {
        private readonly IMongoCollection<Model.ProjectLeader> _projectLeaders;
        private readonly ITeamsService _teamsService;

        public ProjectLeadersService(ILapSimDatabaseSettings settings, ITeamsService teamService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _projectLeaders = database.GetCollection<Model.ProjectLeader>(settings.ProjectLeadersCollectionName);
            _teamsService = teamService;
        }
        public void Delete(string userName) =>
            _projectLeaders.DeleteOne(leader => leader.Id == userName);


        public bool Exists(string userName) =>
            _projectLeaders.CountDocuments(item => item.Id == userName) == 1;

        public IEnumerable<IProjectLeader> Get() =>
            _projectLeaders.Find(_ => true).ToList().Select(item => Convert(item));


        public IProjectLeader Get(string userName)
        {
            var raw = _projectLeaders.Find(item => item.Id == userName).FirstOrDefault();
            if (raw == null)
                throw new KeyNotFoundException(userName);

            return Convert(raw);
        }

        private static IProjectLeader Convert(ProjectLeader raw)
        {
            return new Data.Interfaces.Implementations.ProjectLeader()
            {
                UserName = raw.Id,
                Teams = raw.Teams?.Select(item => item?.ToString()) ?? new List<string>()
            };
        }

        public bool UserManagesAccount(string userName, string accountId)
        {
            return GetAllowedAccounts(userName).Any(account => account.Id.Equals(accountId));
        }


        private IEnumerable<IAccount> GetAllowedAccounts(string userName)
        {
            try
            {
                var pl = Get(userName);
                return _teamsService.Get(pl.Teams).SelectMany(team => team.Accounts);
            }
            catch(Exception e)
            {
                //TODO: log me
                return Enumerable.Empty<IAccount>();
            }
        }
    }
}

using LapSimBackend.Data.Interfaces;
using LapSimBackend.MongoDb.Model;
using LapSimBackend.Service.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.MongoDb.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IMongoCollection<Team> _teams;
        private readonly IMongoCollection<Simulation> _simulations;


        public TeamsService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _teams = database.GetCollection<Team>(settings.TeamsCollectionName);
            _simulations = database.GetCollection<Simulation>(settings.SimulationsCollectionName);
        }

        public IEnumerable<ITeam> Get() =>
            _teams.Find(team => true).ToList().Select(item => Convert(item));

        public ITeam Get(string id)
        {
            var rawTeam = _teams.Find(team => team.Id == id).FirstOrDefault();
            if (rawTeam == null)
                throw new KeyNotFoundException(id);

            return Convert(rawTeam);
        }

        private ITeam Convert(Team rawTeam)
        {
            var accountIds = rawTeam.Accounts?.Select(account => account.UniqueName);
            // TODO: select only budget info????
            var rawSimulations = _simulations.Find(item => accountIds.Contains(item.AccountId));

            return new Data.Interfaces.Implementations.Team()
            {
                Id = rawTeam.Id,
                Budget = rawTeam.Budgets.Sum(item => item.Units), //TODO: filter out the Expired ones,
                UsedBudget = rawSimulations?.ToList().Sum(item => item.UsedBudget) ?? 0,
                Accounts = rawTeam.Accounts,
                Name = rawTeam.Name
            };
        }

        public IEnumerable<ITeam> Get(IEnumerable<string> ids) => _teams.Find(item => ids.Contains(item.Id)).ToList().Select(item => Convert(item));
        

        public void Remove(ITeam teamIn) =>
            _teams.DeleteOne(team => team.Id == teamIn.Id);

        public void Remove(string id) =>
            _teams.DeleteOne(team => team.Id == id);

      
    }
}


using LapSimBackend.Models;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IMongoCollection<Team> _teams;

        public TeamsService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _teams = database.GetCollection<Team>(settings.TeamsCollectionName);
        }

        public IEnumerable<Team> Get() =>
            _teams.Find(team => true).ToList();

        public Team Get(string id) =>
            _teams.Find(team => team.Id == id).FirstOrDefault();

        public IEnumerable<Team> Get(IEnumerable<string> ids)
            => _teams.Find(team => ids.Contains(team.Id)).ToList();


        public Team Create(Team team)
        {
            _teams.InsertOne(team);
            return team;
        }

        public void Update(string id, Team teamIn) =>
            _teams.ReplaceOne(team => team.Id == id, teamIn);

        public void Remove(Team teamIn) =>
            _teams.DeleteOne(team => team.Id == teamIn.Id);

        public void Remove(string id) =>
            _teams.DeleteOne(team => team.Id == id);
    }
}


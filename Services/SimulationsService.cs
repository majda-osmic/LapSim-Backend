using LapSimBackend.Models;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LapSimBackend.Services
{
    public class SimulationsService : ISimulationsService
    {
        private readonly IMongoCollection<Simulation> _simulationsCollection;

        public SimulationsService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _simulationsCollection = database.GetCollection<Simulation>(settings.SimulationsCollectionName);
        }

      
        public List<Simulation> Get()
                =>   _simulationsCollection.Find(_ => true).ToList();

        public Simulation Get(string id)
               => _simulationsCollection.Find(item => item.Id == id).FirstOrDefault();


        public List<Simulation> GetByAccount(string accountId)
        => _simulationsCollection.Find(item => item.AccountId == accountId).ToList();

    }
}

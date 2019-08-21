using LapSimBackend.Data.Interfaces;
using LapSimBackend.MongoDb.Model;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.MongoDb.Services
{
    public class SimulationsService : ISimulationsService
    {
        private readonly IMongoCollection<Simulation> _simulationsCollection;

        public SimulationsService(Model.ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _simulationsCollection = database.GetCollection<Simulation>(settings.SimulationsCollectionName);
        }

        public IEnumerable<ISimulation> Get() => _simulationsCollection.Find(_ => true).ToList();

        public ISimulation Get(string id)
               => _simulationsCollection.Find(item => item.Id == id).FirstOrDefault();


        public IEnumerable<ISimulation> GetByAccount(string accountId)
        => _simulationsCollection.Find(item => item.AccountId == accountId).ToList().Select(item => item as ISimulation);

    }
}

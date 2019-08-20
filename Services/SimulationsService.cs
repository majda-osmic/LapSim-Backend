using LapSimBackend.Models;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System;
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

        public List<Simulation> Get() => _simulationsCollection.Find(_ => true).ToList();
    }
}

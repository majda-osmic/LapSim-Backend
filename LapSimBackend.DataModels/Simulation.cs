using LapSimBackend.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LapSimBackend.DataModels
{
    public class Simulation : ISimulation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CPUs { get; set; }
        public int UsedBudget { get; set; }
        public int Runs { get; set; }
        public string Location { get; set; }
    }
}

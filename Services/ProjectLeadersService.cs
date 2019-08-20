using LapSimBackend.Models;
using LapSimBackend.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Services
{

 
    public class ProjectLeadersService : IProjectLeadersService
    {
        private readonly IMongoCollection<ProjectLeader> _projectLeaders;

        public ProjectLeadersService(ILapSimDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _projectLeaders = database.GetCollection<ProjectLeader>(settings.ProjectLeadersCollectionName);
        }

        public ProjectLeader Create(ProjectLeader leader)
        {
            _projectLeaders.InsertOne(leader);
            return leader;
        }

        public void Delete(string userName) =>
            _projectLeaders.DeleteOne(leader => leader.Id == userName);


        public bool Exists(string userName) =>
            _projectLeaders.CountDocuments(item => item.Id == userName) == 1;

        public IEnumerable<ProjectLeader> Get() =>
            _projectLeaders.Find(_ => true).ToList();


        public ProjectLeader Get(string userName) =>
            _projectLeaders.Find(item => item.Id == userName).FirstOrDefault();


        public void Update(string id, ProjectLeader projectLeaderIn) =>
                  _projectLeaders.ReplaceOne(projectLeader => projectLeader.Id == id, projectLeaderIn);

    }
}

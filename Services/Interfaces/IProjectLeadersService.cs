using LapSimBackend.Models;
using System.Collections.Generic;

namespace LapSimBackend.Services.Interfaces
{
    public interface IProjectLeadersService
    {
        ProjectLeader Create(ProjectLeader leader);
        IEnumerable<ProjectLeader> Get();
        bool Exists(string userName);
        ProjectLeader Get(string userName);
        void Delete(string userName);
        void Update(string id, ProjectLeader projectLeaderIn);
    }
}

using System.Collections.Generic;
using LapSimBackend.Models;

namespace LapSimBackend.Services
{
    public interface ITeamsService
    {
        Team Create(Team team);
        IEnumerable<Team> Get();
        Team Get(string id);
        void Remove(string id);                   
        void Update(string id, Team teamIn);
    }
}
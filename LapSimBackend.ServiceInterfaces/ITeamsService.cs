using System.Collections.Generic;
using LapSimBackend.Data.Interfaces;

namespace LapSimBackend.Service.Interfaces
{
    public interface ITeamsService
    {
        IEnumerable<ITeam> Get();
        ITeam Get(string id);
        IEnumerable<ITeam> Get(IEnumerable<string> id);
        void Remove(string id);                   
    }
}
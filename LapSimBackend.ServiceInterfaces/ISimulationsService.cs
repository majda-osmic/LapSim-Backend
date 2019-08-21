using LapSimBackend.Data.Interfaces;
using System.Collections.Generic;

namespace LapSimBackend.Services.Interfaces
{
    public interface ISimulationsService
    {
        ISimulation Get(string id);
        IEnumerable<ISimulation> Get();
        IEnumerable<ISimulation> GetByAccount(string accountId);
    }
}

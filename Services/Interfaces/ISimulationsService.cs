using LapSimBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Services.Interfaces
{
    public interface ISimulationsService
    {
        Simulation Get(string id);
        List<Simulation> Get();
        List<Simulation> GetByAccount(string accountId);
    }
}

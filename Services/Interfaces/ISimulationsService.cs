using LapSimBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Services.Interfaces
{
    public interface ISimulationsService
    {
        List<Simulation> Get();
    }
}

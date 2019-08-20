using LapSimBackend.Models;
using LapSimBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationsController
    {
        private readonly ISimulationsService _simulationService;

        public SimulationsController(ISimulationsService projectLeadersService)
        {
            _simulationService = projectLeadersService;
        }


        [HttpGet]
        public ActionResult<List<Simulation>> Get() =>
            _simulationService.Get().ToList();
    }
}

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
    public class SimulationsController : ControllerBase
    {
        private readonly ISimulationsService _simulationService;

        public SimulationsController(ISimulationsService simulationService)
        {
            _simulationService = simulationService;
        }


        [HttpGet]
        public ActionResult<List<Simulation>> Get() =>
            _simulationService.Get().ToList();

        [HttpGet("account/{accountId}")]
        public ActionResult<List<Simulation>> GetByAccount(string accountId)
        {
            var accounts = _simulationService.GetByAccount(accountId);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Simulation> Get(string id)
        {
            var account = _simulationService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }
    }
}

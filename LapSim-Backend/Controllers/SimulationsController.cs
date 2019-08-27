using LapSimBackend.Data.Interfaces;
using LapSimBackend.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Controllers
{
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
        public ActionResult<List<ISimulation>> Get() =>
            _simulationService.Get().ToList();

        [HttpGet("account/{accountId}")]
        public ActionResult<IEnumerable<ISimulation>> GetByAccount(string accountId)
        {
            var accounts = _simulationService.GetByAccount(accountId);

            if (accounts == null)
            {
                return NotFound();
            }

            return Ok(accounts);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<ISimulation> Get(string id)
        {
            var account = _simulationService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}

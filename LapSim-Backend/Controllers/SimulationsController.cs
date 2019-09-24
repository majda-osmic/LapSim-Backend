using LapSimBackend.Data.Interfaces;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SimulationsController : ControllerBase
    {
        private readonly ISimulationsService _simulationService;
        private readonly IProjectLeadersService _projectLeadersService;

        public SimulationsController(ISimulationsService simulationService, IProjectLeadersService projectLeaderService)
        {
            _simulationService = simulationService;
            _projectLeadersService = projectLeaderService;
        }


        [HttpGet]
        public ActionResult<List<ISimulation>> Get() =>
            _simulationService.Get().ToList();

        [HttpGet("account/{accountId}")]
        public ActionResult<IEnumerable<ISimulation>> GetByAccount(string accountId)
        {
            if (!CanCurrentUserAccessAccount(accountId))
            {
                return Forbid();
            }

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
            var simulation = _simulationService.Get(id);

            if (simulation == null)
            {
                return NotFound();
            }

            if (!CanCurrentUserAccessAccount(simulation.AccountId))
            {
                return Forbid();
            }

            return Ok(simulation);
        }

        private bool CanCurrentUserAccessAccount(string accountId)
        {
            return User.IsInRole(Role.Admin) || _projectLeadersService.UserManagesAccount(User.Identity.Name, accountId);
        }
    }
}

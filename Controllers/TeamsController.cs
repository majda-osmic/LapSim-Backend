using LapSimBackend.Models;
using LapSimBackend.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        private readonly IProjectLeadersService _projectLeadersService;


        public TeamsController(ITeamsService teamsService, IProjectLeadersService projectLeadersService)
        {
            _teamsService = teamsService;
            _projectLeadersService = projectLeadersService;
        }

        [HttpGet]
        public ActionResult<List<Team>> Get() =>
            _teamsService.Get().ToList();


        [HttpGet("{id:length(24)}", Name = "GetTeam")]
        public ActionResult<Team> Get(string id)
        {
            var teams = _teamsService.Get(id);

            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }

        [HttpPost]
        public ActionResult<Team> Create(Team team)
        {
            _teamsService.Create(team);

            //Calls CreatedAtRoute in the Create action method to return an HTTP 201 response.
            //Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server.
            //CreatedAtRoute also adds a Location header to the response.
            //The Location header specifies the URI of the newly created book.
            return CreatedAtRoute("GetTeam", new { id = team.Id.ToString() }, team);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Team teamIn)
        {
            var account = _teamsService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            _teamsService.Update(id, teamIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var account = _teamsService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            _teamsService.Remove(account.Id);

            return NoContent();
        }
    }
}


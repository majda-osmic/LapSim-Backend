using LapSimBackend.Data.Interfaces;
using LapSimBackend.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LapSimBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles = Role.Admin)]
        public ActionResult<IEnumerable<ITeam>> Get() =>
           Ok(_teamsService.Get());


        [HttpGet("{id:length(24)}", Name = "GetTeam")]
        public ActionResult<ITeam> Get(string id)
        {
            var pl = _projectLeadersService.Get(User.Identity.Name); //TODO: caching
            if (!User.IsInRole(Role.Admin) && !pl.Teams.Contains(id))
            {
                return Forbid();
            }

            var teams = _teamsService.Get(id);
            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }


        [HttpGet("pl/{userName}")]
        public ActionResult<IEnumerable<ITeam>> GetByProjectLeader(string userName)
        {
            if (!User.IsInRole(Role.Admin) && !User.Identity.Name.Equals(userName))
            {
                return Forbid();
            }

            var pl = _projectLeadersService.Get(userName);

            if (pl?.Teams == null)
            {
                return NotFound();
            }
            var teamIds = pl.Teams.Select(item => item?.ToString());
            var teams = _teamsService.Get(teamIds);

            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }

        //[HttpPost]
        //public ActionResult<ITeam> Create(ITeam team)
        //{
        //    _teamsService.Create(team);

        //    //Calls CreatedAtRoute in the Create action method to return an HTTP 201 response.
        //    //Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server.
        //    //CreatedAtRoute also adds a Location header to the response.
        //    //The Location header specifies the URI of the newly created book.
        //    return CreatedAtRoute("GetTeam", new { id = team.Id.ToString() }, team);
        //}

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, ITeam teamIn)
        //{
        //    var account = _teamsService.Get(id);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    _teamsService.Update(id, teamIn);

        //    return NoContent();
        //}

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = Role.Admin)]
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


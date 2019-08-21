using LapSimBackend.Data.Interfaces;
using LapSimBackend.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LapSimBackend.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectLeadersController : ControllerBase
    {
        private readonly IProjectLeadersService _projectLeadersService;

        public ProjectLeadersController(IProjectLeadersService projectLeadersService)
        {
            _projectLeadersService = projectLeadersService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<IProjectLeader>> Get() =>
            Ok(_projectLeadersService.Get());
    }
}

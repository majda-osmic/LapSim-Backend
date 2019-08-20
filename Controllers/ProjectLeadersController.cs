using LapSimBackend.Models;
using LapSimBackend.Services;
using LapSimBackend.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectLeadersController
    {
        private readonly IProjectLeadersService _projectLeadersService;

        public ProjectLeadersController(IProjectLeadersService projectLeadersService)
        {
            _projectLeadersService = projectLeadersService;
        }


        [HttpGet]
        public ActionResult<List<ProjectLeader>> Get() =>
            _projectLeadersService.Get().ToList();
    }
}

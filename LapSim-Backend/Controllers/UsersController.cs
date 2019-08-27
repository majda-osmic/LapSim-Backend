using LapSimBackend.DTOs;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LapSimBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService service)
        {
            _userService = service;

            //TODO: store secrets: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            try //TODO: try - catch app exceptions in one place
            { 
                if (!_userService.Authenticate(userParam.UserName, userParam.Password))
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]User userParam)
        {
            try
            {
                // save 
                _userService.Create(userParam.UserName, userParam.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                //custom eception with messages that do not leak implementation
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                //custom eception with messages that do not leak implementation
                return BadRequest(new { message = "Oh oh, something went terribly wrong. Please contact support!" });
            }

        }

    }
}

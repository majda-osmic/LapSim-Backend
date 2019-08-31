using LapSimBackend.DTOs;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LapSimBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        private AppSettings _appSettings;

        public UsersController(IUserService service, IOptions<AppSettings> settings)
        {
            _userService = service;
            _appSettings = settings.Value;

            //TODO: store secrets: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            try //TODO: try - catch app exceptions in one place
            {
                var user = _userService.Authenticate(userParam.UserName, userParam.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                //https://jasonwatmore.com/post/2019/01/08/aspnet-core-22-role-based-authorization-tutorial-with-example-api
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return Ok(user);

            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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

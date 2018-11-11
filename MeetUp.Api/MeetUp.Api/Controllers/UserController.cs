using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.Model;
using MeetUp.Data.ViewModel;
using MeetUp.Service.Implementation;
using MeetUp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MeetUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }


            if (_userService.UsernameExists(user.Username))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Username already exist");
            }

            if (!_userService.AddUser(user))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginViewModel model)
        {

            if (!_userService.UsernameExists(model.Username))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Wrong username");
            }

            if (_userService.UserLogin(model.Username, model.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:3029",
                    audience: "http://localhost:3000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var user = _userService.GetUserByUsername(model.Username);
                return Ok(new { Token = tokenString, Id = user.Id });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
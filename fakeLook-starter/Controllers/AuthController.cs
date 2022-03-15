using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using fakeLook_models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _repo;
        private ITokenService _tokenService { get; }

        public AuthController(IUserRepository repo,ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _repo.GetByUsernameAndPassword(user.Name,user.Password);
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] User user)
        {
            var dbUser = _repo.Post(user);
      //      var token = _tokenService.CreateToken(dbUser);
            return Ok(new { dbUser });
        }

        [Authorize]
        [HttpGet]
        [Route("TestAll")]

        public IActionResult TestAll()
        {
            return Ok();
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("TestAdmin")]
        public IActionResult TestAdmin()
        {
            return Ok();
        }

    }
}

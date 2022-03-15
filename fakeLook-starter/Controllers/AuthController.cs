using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepository<User> _repo;
        private ITokenService _tokenService { get; }

        public AuthController(IRepository<User> repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _repo.GetByPredicate(p => p.Mail == user.Mail && p.Password == user.Password)?.FirstOrDefault();
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }


    }
}

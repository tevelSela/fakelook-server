using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Login([FromBody] UserLite user)
        {
            var dbUser = _repo.GetByPredicate(p => p.Mail == user.Mail && p.Password == user.Password)?.FirstOrDefault();
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] UserLite user)
        {
            var ExistingUser = _repo.GetByPredicate(f => f.Mail == user.Mail)?.ToList();
            if (ExistingUser != null) return Problem("Mail already exists");
            var dbUser = _repo.Post(ExistingUser.FirstOrDefault());
            var token = _tokenService.CreateToken(ExistingUser.FirstOrDefault());
            return Ok(new { token });
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(UserLite user)
        {
            var dbUser = _repo.GetByPredicate(f => f.Mail == user.Mail)?.ToList();
            dbUser.FirstOrDefault().Password = user.Password;
            if (dbUser == null) return Problem("Non existing mail adress");
            try
            {
                await _repo.Edit(dbUser.FirstOrDefault());
            }
            catch(Exception e)
            {
                return Problem(e.Message);
            }
            return Ok(new { dbUser[0].Password});  
        }

        [Authorize]
        [HttpGet]
        [Route("Micha")]
        public IActionResult okM(int liron)
        {
            return Ok();
        }
    }
}

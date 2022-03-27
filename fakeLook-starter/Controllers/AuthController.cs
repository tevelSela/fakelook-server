using auth_example.Filters;
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
            return Ok(new { token, dbUser });
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] User user)
        {
            var ExistingUser = _repo.GetByPredicate(f => f.Mail == user.Mail)?.ToList();
            if (ExistingUser.Count() != 0) return Problem("Mail already exists");
            var dbUser = _repo.Post(user);
            var token = _tokenService.CreateToken(user);
            return Ok(new { token, dbUser });
        }
        //request.routhvalue.user
        //[TypeFilter(typeof(theFilter))]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(UserLite user)
        {
            var dbUser = _repo.GetByPredicate(f => f.Mail == user.Mail)?.ToList();
            if (dbUser.Count != 0) dbUser.FirstOrDefault().Password = user.Password;
            else return Problem("Non existing mail adress");
            try
            {
                await _repo.Edit(dbUser.FirstOrDefault());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return _repo.GetAll().ToList();
        }

        [Authorize]
        [HttpPost]
        [Route("GetUserById")]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<User> GetUserById([FromBody] int id)
        {
            return _repo.GetByPredicate(f => f.Id==id)?.FirstOrDefault();
        }
    }
}

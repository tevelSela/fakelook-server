using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fakeLook_starter.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using fakeLook_models.Models;

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _Postrepository;

        public PostsController(IPostRepository Postrepository)
        {
            _Postrepository = Postrepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return _Postrepository.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Post>> GetPost(int id)
        //{
        //    return _Postrepository.GetById(id);
        //}
    }
}

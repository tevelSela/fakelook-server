using fakeLook_starter.Repositories;
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
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return _postRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return _postRepository.GetById(id.ToString());
        }
    }
}

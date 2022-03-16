using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fakeLook_starter.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using fakeLook_models.Models;
using auth_example.Filters;

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
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return _postRepository.GetAll();
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return _postRepository.GetById(id);
        }

        [Route("publish")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult PublishPost([FromBody]Post post)
        {
            var user = (User)Request.RouteValues["user"];
            post.UserId = user.Id;
            _postRepository.Add(post);
            return Ok(new {post});
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post=_postRepository.GetById(id);
            if (post != null)
            {
               await _postRepository.Delete(id);
            }
            return Ok();
        }
        /*

        public IActionResult EditPost([FromBody]Post post)
        {
            if(post.Id)
        }
        */

    }
}

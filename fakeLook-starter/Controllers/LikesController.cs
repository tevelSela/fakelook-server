using auth_example.Filters;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public LikesController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [Authorize]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<Like>> GetLikes(int postId)
        {
            return _likeRepository.GetByPredicate(l => l.PostId == postId);
        }

        [Authorize]
        [Route("Revoke")]
        [HttpDelete]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IActionResult> RevokeLike(int postId)
        {
            var user = (User)Request.RouteValues["user"];
            var like = GetLikesByPostId(postId).Result.Where(l => l.UserId == user.Id).FirstOrDefault();
            if (like != null)
            {
                await _likeRepository.Delete(like.Id);
            }
            return Ok();
        }

        [Route("CountLikes")]
        [Authorize]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<int> GetCountLikesByPostId(int postId)
        {
            return GetLikesByPostId(postId).Result.Count();

        }

        [Authorize]
        [HttpGet("{postId}")]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<List<Like>> GetLikesByPostId(int postId)
        {
            var allLikes = _likeRepository.GetByPredicate(l => l.PostId == postId)?.ToList();
            if (allLikes == null) throw new NullReferenceException("No Such Post");
            return allLikes;
        }

        [Authorize]
        [Route("add")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult addLike([FromBody] Like like)
        {
            var user = (User)Request.RouteValues["user"];
            like.UserId = user.Id;
            _likeRepository.Add(like);
            return Ok(new { like });
        }
    }
}

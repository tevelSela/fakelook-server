using auth_example.Filters;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace fakeLook_starter.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository CommentRepository)
        {
           _commentRepository = CommentRepository;
        }

        [Authorize]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<Comment>> GetComents()
        {
            return _commentRepository.GetAll();
        }

        [Authorize]
        [Route("add")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult addComment([FromBody] Comment comment, params UserTaggedComment[]? tags)
        {
            var user = (User)Request.RouteValues["user"];
            comment.UserId = user.Id;
            _commentRepository.Add(comment);
            if (tags != null)
                tags.ToList().ForEach(t => _commentRepository.AddCommentTag(t));
            return Ok(new { comment });
        }

        [Authorize]
        [Route("addTags")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult addCTags(params UserTaggedComment[]? tags)
        {
            tags.ToList().ForEach(t => _commentRepository.AddCommentTag(t));
            return Ok();
        }

        [Route("Delete")]
        [Authorize]
        [HttpDelete]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var post = _commentRepository.GetById(id);
            if (post != null)
            {
                await _commentRepository.Delete(id);
            }
            return Ok();
        }

        [Authorize]
        [Route("Edit")]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult EditComment([FromBody] Comment comment, params Tag[]? tags)
        {
            var currPost = _commentRepository.GetById(comment.Id);
            if (currPost == null) return Problem("Comment Dosen't exist");
           // if (ta)
            _commentRepository.Edit(currPost);
            return Ok();
        }


      

    }
}

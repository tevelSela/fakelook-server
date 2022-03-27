﻿using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fakeLook_starter.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using fakeLook_models.Models;
using auth_example.Filters;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

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

        [Authorize]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return _postRepository.GetAll();
        }

        [Route("getByFilter")]
        [Authorize]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<IEnumerable<Post>> GetPostsByFilter(QueryRequest filter)
        {
            var Listtags = filter.tags.ToList();
            IEnumerable<Post> entities = Enumerable.Empty<Post>();
            var tomorrow = DateTime.Today.AddDays(1);
            if (filter.fromDate.Year != 1990 || filter.toDate.Day != tomorrow.Day)
            {
                entities = _postRepository.GetAll()
                  .Where(p => (p.Date >= filter.fromDate && p.Date <= filter.toDate));
            }
            if (Listtags.Count() > 0)
            {
                entities = entities.Where(p => p.Tags.Where(t => Listtags.Any(ot => ot.Equals(t.Content))).Count() != 0);
            }

            return entities;
        }
        // var entities= _postRepository.GetByPredicate(p => p.Date >= filter.fromDate && p.Date <= filter.toDate);
        [HttpGet("{id}")]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return _postRepository.GetById(id);
        }

        [Authorize]
        [Route("publish")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult PublishPost([FromBody] Post post)
        {
            var user = (User)Request.RouteValues["user"];
            post.UserId = user.Id;
            _postRepository.Add(post);
            return Ok(new { post });
        }

        [Authorize]
        [HttpDelete]
        [TypeFilter(typeof(GetUserActionFilter))]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            if (post != null)
            {
                await _postRepository.Delete(id);
            }
            return Ok();
        }

        [Authorize]
        [Route("Edit")]
        [HttpGet]
        [TypeFilter(typeof(GetUserActionFilter))]
        public IActionResult EditPost([FromBody] Post post)
        {
            var currPost = _postRepository.GetById(post.Id);
            if (currPost == null) return Problem("Post Dosen't exist");
            _postRepository.Edit(currPost);
            return Ok();
        }


    }
}

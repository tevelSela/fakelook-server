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
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [Authorize]
        [Route("add")]
        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        public Tag AddTag([FromBody] Tag tag)
        {
                var res = _tagRepository.Add(tag);
                return res.Result;
        }

        //[Authorize]
        //[HttpGet("{postId}")]
        //[TypeFilter(typeof(GetUserActionFilter))]
        //public async Task<List<Tag>> GetTagsByPostId(int postId)
        //{
        //    var allTags = _tagRepository.GetByPredicate(l => l.Posts.)?.ToList();
        //    if (allTags == null) throw new NullReferenceException("No Such Post");
        //    return allTags;
        //}
    }
}

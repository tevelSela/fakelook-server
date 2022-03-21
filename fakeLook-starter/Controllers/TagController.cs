using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fakeLook_starter.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
    }
}

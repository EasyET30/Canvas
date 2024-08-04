
using Microsoft.AspNetCore.Mvc;
using Canvas_API.EC;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;
using System.Text.Json;

namespace Canvas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentItemController : ControllerBase
    {
        private readonly ILogger<ContentItemController> _logger;

        public ContentItemController(ILogger<ContentItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string? Get()
        {
            return JsonSerializer.Serialize(new ContentItemEC().Search());
        }

        [HttpGet("GetById/{Id}")]
        public string? GetId(string Id)
        {
            return JsonSerializer.Serialize(new ContentItemEC().Get(Id));
        }

        [HttpDelete("Delete/{Id}")]
        public string? Delete(string Id)
        {
            return JsonSerializer.Serialize(new ContentItemEC().Delete(Id));
        }

        [HttpPost("Post")]
        public string? AddOrUpdate([FromBody]ContentItemDTO ContentItem)
        {
            return JsonSerializer.Serialize(new ContentItemEC().AddOrUpdate(ContentItem));
        }

        [HttpPost("Search")]
        public string? Search([FromBody]QueryMessage query)
        {
            return JsonSerializer.Serialize(new ContentItemEC().Search(query.Query));
        }
    }
}

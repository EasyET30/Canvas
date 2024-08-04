using Microsoft.AspNetCore.Mvc;
using Canvas_API.EC;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;
using System.Text.Json;

namespace Canvas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string? Get()
        {
            return JsonSerializer.Serialize(new CourseEC().Search());
        }

        [HttpGet("GetById/{id}")]
        public string? GetId(string id)
        {
            return JsonSerializer.Serialize(new CourseEC().Get(id));
        }

        [HttpDelete("Delete/{id}")]
        public string? Delete(string id)
        {
            return JsonSerializer.Serialize(new CourseEC().Delete(id));
        }

        [HttpPost("Post")]
        public string? AddOrUpdate([FromBody]CourseDTO course)
        {
            return JsonSerializer.Serialize(new CourseEC().AddOrUpdate(course));
        }

        [HttpPost("Search")]
        public string? Search([FromBody]QueryMessage query)
        {
            return JsonSerializer.Serialize(new CourseEC().Search(query.Query));
        }
    }
}

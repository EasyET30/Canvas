
using Microsoft.AspNetCore.Mvc;
using Canvas_API.EC;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;
using System.Text.Json;

namespace Canvas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string? Get()
        {
            return JsonSerializer.Serialize(new AssignmentEC().Search());
        }

        [HttpGet("GetById/{Id}")]
        public string? GetId(string Id)
        {
            return JsonSerializer.Serialize(new AssignmentEC().Get(Id));
        }

        [HttpDelete("Delete/{Id}")]
        public string? Delete(string Id)
        {
            return JsonSerializer.Serialize(new AssignmentEC().Delete(Id));
        }

        [HttpPost("Post")]
        public string? AddOrUpdate([FromBody]AssignmentDTO Assignment)
        {
            return JsonSerializer.Serialize(new AssignmentEC().AddOrUpdate(Assignment));
        }

        [HttpPost("Search")]
        public string? Search([FromBody]QueryMessage query)
        {
            return JsonSerializer.Serialize(new AssignmentEC().Search(query.Query));
        }
    }
}

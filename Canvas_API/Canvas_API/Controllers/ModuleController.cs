
using Microsoft.AspNetCore.Mvc;
using Canvas_API.EC;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;
using System.Text.Json;

namespace Canvas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;

        public ModuleController(ILogger<ModuleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string? Get()
        {
            return JsonSerializer.Serialize(new ModuleEC().Search());
        }

        [HttpGet("GetById/{Id}")]
        public string? GetId(string Id)
        {
            return JsonSerializer.Serialize(new ModuleEC().Get(Id));
        }

        [HttpDelete("Delete/{Id}")]
        public string? Delete(string Id)
        {
            return JsonSerializer.Serialize(new ModuleEC().Delete(Id));
        }

        [HttpPost("Post")]
        public string? AddOrUpdate([FromBody]ModuleDTO Module)
        {
            return JsonSerializer.Serialize(new ModuleEC().AddOrUpdate(Module));
        }

        [HttpPost("Search")]
        public string? Search([FromBody]QueryMessage query)
        {
            return JsonSerializer.Serialize(new ModuleEC().Search(query.Query));
        }
    }
}

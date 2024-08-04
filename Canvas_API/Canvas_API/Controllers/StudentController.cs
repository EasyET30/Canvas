using Microsoft.AspNetCore.Mvc;
using Canvas_API.EC;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;
using System.Text.Json;


namespace Canvas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string? Get()
        {
            return JsonSerializer.Serialize(new StudentEC().Search());
        }

        [HttpGet("GetById/{id}")]
        public string? GetId(string Id)
        {
            return JsonSerializer.Serialize(new StudentEC().Get(Id));
        }

        [HttpDelete("Delete/{id}")]
        public string? Delete(string Id)
        {
            return JsonSerializer.Serialize(new StudentEC().Delete(Id));
        }

        [HttpPost("Post")]
        public string? AddOrUpdate([FromBody]StudentDTO Student)
        {
            return JsonSerializer.Serialize(new StudentEC().AddOrUpdate(Student));
        }

        [HttpPost("Search")]
        public string? Search([FromBody]QueryMessage query)
        {
            return JsonSerializer.Serialize(new StudentEC().Search(query.Query));
        }
    }
}

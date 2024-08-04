using Library_Canvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Canvas.DTO
{
    public class CourseDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public CourseDTO()
        {
            Id = string.Empty;
            Name = string.Empty;
            Code = string.Empty;
        }
        public CourseDTO(Course c)
        {
            Id = c.Id;
            Name = c.Name;
            Code = c.Code;
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}

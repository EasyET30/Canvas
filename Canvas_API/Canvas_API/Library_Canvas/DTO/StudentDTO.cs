using Library_Canvas.Models;
namespace Library_Canvas.DTO {
    public class StudentDTO{
        public string Name {get; set;}
        public StudentClassification Classification {get; set;}
        //public string GPA {get; set;}
        public string? Id{get; set;}
        public List<string> EnrolledCourses;

        public StudentDTO() { 
            Name = string.Empty;
            //GPA = string.Empty;
            Id = string.Empty;
            Classification = 0;
            EnrolledCourses = new List<string>();
        }
        
        public StudentDTO(Student s) {
            Name = s.Name;
            //GPA = string.Empty;
            Id = s.Id;
            Classification = s.Classification;
            EnrolledCourses = new List<string>(s.EnrolledCourses);
        }
        
        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
    }
}

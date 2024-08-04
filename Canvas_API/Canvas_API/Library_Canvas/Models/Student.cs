using Library_Canvas.DTO;
namespace Library_Canvas.Models {

    public enum StudentClassification{
        Freshman, Sophomore, Junior, Senior
    }
    public class Student : Item{
        
        public string Name {get; set;}
        public StudentClassification Classification {get; set;}
        //public string GPA {get; set;}
        //public string? Id {get; set;}
        public List<string> EnrolledCourses;

        public Student() { 
            Name = string.Empty;
            //GPA = string.Empty;
            Id = string.Empty;
            Classification = StudentClassification.Freshman;
            EnrolledCourses = new List<string>();
        }
        
        public Student(StudentDTO dto) {
            Name = dto.Name;
            //GPA = string.Empty;
            Id = dto.Id;
            Classification = dto.Classification;
            EnrolledCourses = new List<string>(dto.EnrolledCourses);
        }
        /*
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
        */
    }
}

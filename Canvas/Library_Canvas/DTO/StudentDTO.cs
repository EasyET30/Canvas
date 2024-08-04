namespace Library_Canvas.DTO {
    public enum StudentClassification{
    Freshman, Sophomore, Junior, Senior
    }
    public class StudentDTO{
        public string Name {get; set;}
        public StudentClassification Classification {get; set;}
        //public string GPA {get; set;}
        public string Id {get; set;}
        public List<string> EnrolledCourses;


        public StudentDTO() { 
            Name = string.Empty;
            //GPA = string.Empty;
            Id = string.Empty;
            Classification = 0;
            EnrolledCourses = new List<string>();
        }
        
        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
    }
}

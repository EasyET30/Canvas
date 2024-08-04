
using Library_Canvas.DTO;

namespace Library_Canvas.Models {
    public class Course : Item{
        public string Code {get; set;}
        public string Name {get; set;}
        //public string? Id{get; set;}
        public Course() {
            Name = string.Empty;
            Code = string.Empty;
            Id = string.Empty;
        }
        public Course(CourseDTO dto){
            Id = dto.Id;
            Code = dto.Code;
            Name = dto.Name;
        }
        /*
        public string DetailDisplay(){
            string Created = string.Empty;
            Created += $"{Name} - {Code}\n\nAssignments:\n";
            Assignments.ForEach(c=> Created += c.ToString() + "\n");
            Created += "\nModule:\n";
            Modules.ForEach(c=> Created += c.ToString() + "\n");
            return Created;
        }
        

        public override string ToString(){
            return $"{Code} - {Name}";
        }
        public List<Student> DisplayRoster(){
            return Roster;
        }
        */
    }
}

using Library_Canvas.Models;
namespace Library_Canvas.DTO {

    public class ModuleDTO{

        public string Name {get; set;}
        public string Description {get; set;}
        public string? Id {get; set;}
        public string CourseId{get; set;}

        public ModuleDTO() {
            Name = string.Empty;
            Description = string.Empty;
            Id = string.Empty;
            CourseId = string.Empty;
        }
        public ModuleDTO(Module m) {
            Name = m.Name;
            Description = m.Description;
            Id = m.Id;
            CourseId = m.CourseID;
        }

        public override string ToString(){
            return $"{Name} - {Description}";//\nContents:{DisplayContents()}";
        }
/*
        public String DisplayContents(){
            String CreatedString = string.Empty;
            foreach(ContentItem current in Content){
                CreatedString += $"\n{current.Name} - {current.Description}";
            }
            return CreatedString;
        }
        */
    }
}
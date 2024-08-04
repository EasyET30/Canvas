using Library_Canvas.DTO;
namespace Library_Canvas.Models {

    public class Module : Item{

        public string Name {get; set;}
        public string Description {get; set;}
        //public string? Id {get; set;}
        public string CourseID {get; set;}

        public Module() {
            Name = string.Empty;
            Description = string.Empty;
            Id = string.Empty;
            CourseID = string.Empty;
        }
        public Module(ModuleDTO dto) {
            Name = dto.Name;
            Description = dto.Description;
            Id = dto.Id;
            CourseID = dto.CourseId;
        }

/*
        public override string ToString(){
            return $"{Name} - {Description}\nContents:{DisplayContents()}";
        }

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
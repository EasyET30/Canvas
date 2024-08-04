using Library_Canvas.Services;

namespace Library_Canvas.DTO {

    public class ModuleDTO{

        public string Name {get; set;}
        public string Description {get; set;}
        public string Id {get; set;}
        public string CourseId{get; set;}

        public ModuleDTO() {
            Name = string.Empty;
            Description = string.Empty;
            Id = string.Empty;
            CourseId = string.Empty;
        }

        public override string ToString(){
            return $"{Name} - {Description}\nContents:\n{DisplayContents()}";
        }

        public string DisplayContents(){
            string CreatedString = string.Empty;
            foreach(ContentItemDTO current in ContentItemService.Current.ContentItems){
                if(current.ModuleId == Id){
                    CreatedString += current.ToString();
                }
            }
            return CreatedString;
        }
    }
}
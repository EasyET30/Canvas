using Library_Canvas.DTO;
namespace Library_Canvas.Models {

    public class ContentItem : Item{
        public string Name {get; set;}
        public string Description {get; set;}
        //public string Path{get; set;}
        //public string? Id {get; set;}
        public string ModuleId {get; set;}
        public string CourseId{get; set;}

        public ContentItem(){
            Name = string.Empty;
            Description = string.Empty;
            //Path = string.Empty;
            Id = string.Empty;
            ModuleId = string.Empty;
            CourseId = string.Empty;
        }

        public ContentItem(ContentItemDTO dto){
            Name = dto.Name;
            Description = dto.Description;
            //Path = string.Empty;
            Id = dto.Id;
            ModuleId = dto.ModuleId;
            CourseId = dto.CourseId;
        }
/*
        public override string ToString(){
            return $"{Name} - {Description}\n";
        }
        */
    }
}
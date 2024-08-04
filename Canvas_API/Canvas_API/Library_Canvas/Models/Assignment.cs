using Library_Canvas.DTO;
namespace Library_Canvas.Models {
    public class Assignment : Item{
        //public string? Id { get; set; }
        public string CourseId { get; set; }
        public string Name {get; set;}
        public string Description {get; set;}
        public double TotalPoints {get; set;}
        public string DueDate {get; set;}

        public Assignment() {
            Name = string.Empty;
            Description = string.Empty;
            TotalPoints = 0;
            DueDate = string.Empty;
            Id = string.Empty;
            CourseId = string.Empty;
        }
        public Assignment(AssignmentDTO dto) {
            Name = dto.Name;
            Description = dto.Description;
            TotalPoints = dto.TotalPoints;
            DueDate = dto.DueDate;
            Id = dto.Id;
            CourseId = dto.CourseId;
        }

        public override string ToString()
        {
            return $"{Name}\nTotal Points: {TotalPoints} - Due: {DueDate}\nDescription: {Description}";
        }
        
    }
}
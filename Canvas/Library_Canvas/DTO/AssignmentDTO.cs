namespace Library_Canvas.DTO {
    public class AssignmentDTO{
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string Name {get; set;}
        public string Description {get; set;}
        public double TotalPoints {get; set;}
        public string DueDate {get; set;}

        public AssignmentDTO() {
            Name = string.Empty;
            Description = string.Empty;
            TotalPoints = 0;
            DueDate = string.Empty;
            Id = string.Empty;
            CourseId = string.Empty;
        }
        public override string ToString()
        {
            return $"{Name}\nTotal Points: {TotalPoints} - Due: {DueDate}\nDescription: {Description}";
        }
    }
}
namespace Library_Canvas.DTO
{
    public class CourseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public CourseDTO()
        {
            Id = string.Empty;
            Name = string.Empty;
            Code = string.Empty;
        }
        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}

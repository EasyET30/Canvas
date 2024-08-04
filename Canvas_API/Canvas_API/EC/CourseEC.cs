
using Canvas_API.Databases;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.EC
{
    public class CourseEC
    {
        Filebase Database;
        public CourseEC(){
            Database = Filebase.Current;
        }
        public CourseDTO? AddOrUpdate(CourseDTO dto)
        {
            Course created = new Course(dto);
            var id = Database.AddOrUpdateCourse(created);
            return Get(id);
        }
        public CourseDTO? Get(string Id)
        {
            var returnVal = Database.Courses.FirstOrDefault(p=>p.Id == Id) ?? new Course();
            return new CourseDTO(returnVal);
        }
        public bool Delete(string Id)
        {
            bool returnVal = Database.Delete("Course", Id);
            return returnVal;
        }
        public IEnumerable<CourseDTO> Search(string query = "")
        {
            return Database.Courses.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).Select(m => new CourseDTO(m));
        }
        
    }
}


using Canvas_API.Databases;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.EC
{
    public class StudentEC
    {
        Filebase Database;
        public StudentEC(){
            Database = Filebase.Current;
        }
        public StudentDTO AddOrUpdate(StudentDTO dto)
        {
            Student created = new Student(dto);
            string id = Database.AddOrUpdateStudent(created);
            return Get(id);
        }
        public StudentDTO Get(string Id)
        {
            Student returnVal = Database.Students.FirstOrDefault(p=>p.Id == Id) ?? new Student();
            return new StudentDTO(returnVal);
        }
        public bool Delete(string Id)
        {
            bool returnVal = Database.Delete("Student", Id);
            return returnVal;
        }
        public IEnumerable<StudentDTO> Search(string query = "")
        {
            return Database.Students.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).Select(m => new StudentDTO(m));
        }
        
    }
}

using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;

namespace Library_Canvas.Services
{
    public class StudentService
    {
        private List<StudentDTO> students;
        public List<StudentDTO> Students { 
            get {
                
                return students ?? new List<StudentDTO>();
            } 
        }
        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentService();
                }
                return instance;
            }
        }
        private StudentService()
        {
            var response = new WebRequestHandler().Get("/Student").Result;
            students = JsonSerializer.Deserialize<List<StudentDTO>>(response) ?? new List<StudentDTO>();
        }

        public void Delete(string Id)
        {
            var handler = new WebRequestHandler().Delete($"/Student/Delete/{Id}");
            var StudentToDelete = Students.FirstOrDefault(c => c.Id == Id);
            if(StudentToDelete != null)
            {
                Students.Remove(StudentToDelete);
            }
        }

        public void AddOrUpdate(StudentDTO c) 
        {
            string response = new WebRequestHandler().Post("/Student/Post", c).Result;
            StudentDTO? myUpdatedStudent = JsonSerializer.Deserialize<StudentDTO>(response);
            if(myUpdatedStudent != null)
            {
                if(string.IsNullOrEmpty(c.Id))
                {
                    Students.Add(myUpdatedStudent);
                    return;
                }
                var existingStudent = Students.FirstOrDefault(c => c.Id == myUpdatedStudent.Id);
                if(existingStudent != null)
                {
                    var index = Students.IndexOf(existingStudent);
                    Students.RemoveAt(index);
                    Students.Insert(index, myUpdatedStudent);
                }
            }
        }

        public StudentDTO? Get(string Id)
        {
            var response = new WebRequestHandler().Get($"/Student/GetById/{Id}").Result;
            var Student = JsonSerializer.Deserialize<StudentDTO>(response);
            return Student;
        }

        public IEnumerable<StudentDTO> Search(string query)
        {
            return Students
                .Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}

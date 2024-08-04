using System.Text.Json;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;

namespace Library_Canvas.Services
{
    public class CourseService
    {
        private List<CourseDTO> courses;
        public List<CourseDTO> Courses { 
            get {
                
                return courses ?? new List<CourseDTO>();
            } 
        }

        //private List<Course> Courses;

        private static CourseService? instance;

        public static CourseService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseService();
                }
                return instance;
            }
        }
        private CourseService()
        {
            var response = new WebRequestHandler().Get("/Course").Result;
            courses = JsonSerializer.Deserialize<List<CourseDTO>>(response)?? new List<CourseDTO>();
        }

        public void Delete(string Id)
        {
            var handler = new WebRequestHandler().Delete($"/Course/Delete/{Id}");
            var CourseToDelete = Courses.FirstOrDefault(c => c.Id == Id);
            if(CourseToDelete != null)
            {
                Courses.Remove(CourseToDelete);
            }
        }

        public void AddOrUpdate(CourseDTO c)
        {
            var response = new WebRequestHandler().Post("/Course/Post", c).Result;
            CourseDTO? myUpdatedCourse = JsonSerializer.Deserialize<CourseDTO>(response);
            if(myUpdatedCourse != null)
            {
                var existingCourse = Courses.FirstOrDefault(c => c.Id == myUpdatedCourse.Id);
                if(string.IsNullOrEmpty(c.Id))
                {
                    Courses.Add(myUpdatedCourse);
                }
                if(existingCourse != null)
                {
                    var index = Courses.IndexOf(existingCourse);
                    Courses.RemoveAt(index);
                    Courses.Insert(index, myUpdatedCourse);
                }
            }

        }

        public CourseDTO? Get(string Id)
        {
            var response = new WebRequestHandler()
                    .Get($"/Course/GetById/{Id}")
                    .Result;
            var Course = JsonSerializer.Deserialize<CourseDTO>(response);
            return Course;
            //return Courses.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<CourseDTO> Search(string query)
        {
            return Courses
                .Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}

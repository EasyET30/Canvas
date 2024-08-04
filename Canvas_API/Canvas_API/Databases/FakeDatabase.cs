/*
using Library_Canvas.Models;
namespace Canvas_API.Databases
{
    public static class FakeDatabase
    {
        //Default database tuples
        public static List<Student> Students = new List<Student>{
            new Student { Id = 1, Name = "Student 1", Classification = StudentClassification.Freshman},
            new Student { Id = 2, Name = "Student 2", Classification = StudentClassification.Sophomore},
        };
        public static List<ContentItem> Content = new List<ContentItem>{
            new ContentItem{CourseId = 1, ModuleId = 1, Id = 1, Name = "Notes 1", Description = "Lots of Notes"},
            new ContentItem{CourseId = 1, ModuleId = 1, Id = 2, Name = "Notes 2", Description = "Lots of Notes"},
            new ContentItem{CourseId = 2, ModuleId = 2, Id = 1, Name = "Notes 1", Description = "Lots of Notes"},
            new ContentItem{CourseId = 2, ModuleId = 2, Id = 2, Name = "Notes 2", Description = "Lots of Notes"}
        };
        public static List<Module> Modules = new List<Module>{
            new Module{CourseID = 1, Id = 1, Name = "Module 1", Description = "Notes"},
            new Module{CourseID = 2, Id = 2, Name = "Module 2", Description = "Notes"} 
        };
        public static List<Assignment> Assignments = new List<Assignment>{
            new Assignment{Id = 1, CourseId = 1, Name = "Homework 1", Description = "HW", DueDate = "5/1/24", TotalPoints = 100},
            new Assignment{Id = 2, CourseId = 2, Name = "Homework 2", Description = "HW", DueDate = "5/1/24", TotalPoints = 100}
        };
        public static List<Course> Courses = new List<Course>{
            new Course { Id = 1, Name = "Course 1", Code = "COP"},
            new Course { Id = 2, Name = "Course 2", Code = "COP"}
        };

        //Gets last ids
        public static int LastCourseId => Courses.Any()? Courses.Select(c => c.Id).Max() : 0;
        public static int LastStudentId => Students.Any()? Students.Select(s => s.Id).Max() : 0;
        public static int LastModuleId => Modules.Any()? Modules.Select(m => m.Id).Max() : 0;
        public static int LastContentId => Content.Any()? Content.Select(c => c.Id).Max() : 0;
        public static int LastAssignmentId => Assignments.Any()? Assignments.Select(a => a.Id).Max() : 0;

        //Returns object by id
        public static Student GetByStudentId(int id)
        {
            return Students?.FirstOrDefault(p => p.Id == id) ?? new Student();
        }
        public static Course GetByCourseId(int id)
        {
            return Courses?.FirstOrDefault(p => p.Id == id) ?? new Course();
        }
        public static Module GetByModuleId(int Id){
            return Modules?.FirstOrDefault(p => p.Id == Id) ?? new Module();
        }
        public static Assignment GetByAssignmentId(int Id){
            return Assignments?.FirstOrDefault(p => p.Id == Id) ?? new Assignment();
        }
        public static ContentItem GetByContentItemId(int Id){
            return Content?.FirstOrDefault(p => p.Id == Id) ?? new ContentItem();
        }
    }
}
*/
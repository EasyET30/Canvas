using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.Databases
{
    public class Filebase
    {
        private string _root;
        private string _StudentRoot;
        private string _CourseRoot;
        private string _ModuleRoot;
        private string _ContentItemRoot;
        private string _AssignmentRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = "C:\\Users\\erikm\\Documents\\VSCode\\Canvas_Database";
            _StudentRoot = $"{_root}\\Students";
            _CourseRoot = $"{_root}\\Courses";
            _ModuleRoot = $"{_root}\\Modules";
            _ContentItemRoot = $"{_root}\\ContentItems";
            _AssignmentRoot = $"{_root}\\Assignments";
        }
        public bool Delete(string type, string id)
        {
            string path;
            if (type == "Course"){
                path = $"{_CourseRoot}/{id}.json";
            }else if(type == "Student"){
                path = $"{_StudentRoot}/{id}.json";
            }else if(type == "Module"){
                path = $"{_ModuleRoot}/{id}.json";
            }else if(type == "Assingment"){
                path = $"{_AssignmentRoot}/{id}.json";
            }else if(type == "ContentItem"){
                path = $"{_ContentItemRoot}/{id}.json";
            }else{
                path = "Incorrect Type";
            }

            if(File.Exists(path)){
                File.Delete(path);
                return true;
            }
            return false;
        }
        public string AddOrUpdateStudent(Student item)
        {
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            string path = $"{_StudentRoot}/{item.Id}.json";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonSerializer.Serialize(item));

            return item.Id;
        }
        public string AddOrUpdateCourse(Course item)
        {
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            string path = $"{_CourseRoot}/{item.Id}.json";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonSerializer.Serialize(item));

            return item.Id;
        }
        public string AddOrUpdateModule(Module item)
        {
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            string path = $"{_ModuleRoot}/{item.Id}.json";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonSerializer.Serialize(item));

            return item.Id;
        }
        public string AddOrUpdateAssignment(Assignment item)
        {
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            string path = $"{_AssignmentRoot}/{item.Id}.json";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonSerializer.Serialize(item));

            return item.Id;
        }
        public string AddOrUpdateContentItem(ContentItem item)
        {
            if(string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            string path = $"{_ContentItemRoot}/{item.Id}.json";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonSerializer.Serialize(item));

            return item.Id;
        }
        public List<Course> Courses
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_CourseRoot);
                List<Course> _courses = new List<Course>();
                foreach(FileInfo courseFile in root.GetFiles())
                {
                    Course? course = JsonSerializer.Deserialize<Course>(File.ReadAllText(courseFile.FullName));
                    if(course != null){
                        _courses.Add(course);
                    }
                }
                return _courses;
            }
        }
        public List<Student> Students
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_StudentRoot);
                List<Student> _students = new List<Student>();
                foreach (FileInfo studentFile in root.GetFiles())
                {
                    Student? student = JsonSerializer.Deserialize<Student>(File.ReadAllText(studentFile.FullName));
                    if(student != null){
                        _students.Add(student);
                    }
                }
                return _students;
            }
        }
        public List<Module> Modules
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_ModuleRoot);
                List<Module> _modules = new List<Module>();
                foreach (FileInfo moduleFile in root.GetFiles())
                {
                    Module? module = JsonSerializer.Deserialize<Module>(File.ReadAllText(moduleFile.FullName));
                    if(module != null){
                        _modules.Add(module);
                    }
                }
                return _modules;
            }
        }
        public List<Assignment> Assignments
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_AssignmentRoot);
                List<Assignment> _assignments = new List<Assignment>();
                foreach (FileInfo assignmentFile in root.GetFiles())
                {
                    Assignment? assignment = JsonSerializer.Deserialize<Assignment>(File.ReadAllText(assignmentFile.FullName));
                    if(assignment != null){
                        _assignments.Add(assignment);
                    }
                }
                return _assignments;
            }
        }
        public List<ContentItem> Contents
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_ContentItemRoot);
                List<ContentItem> _contents = new List<ContentItem>();
                foreach (FileInfo contentItemFile in root.GetFiles())
                {
                    ContentItem? contentItem = JsonSerializer.Deserialize<ContentItem>(File.ReadAllText(contentItemFile.FullName));
                    if (contentItem != null){
                        _contents.Add(contentItem);
                    }
                }
                return _contents;
            }
        }
    }
}




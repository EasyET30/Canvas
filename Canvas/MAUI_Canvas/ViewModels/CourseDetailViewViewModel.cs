using Library_Canvas.DTO;
using Library_Canvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Canvas.ViewModels
{
    class CourseDetailViewViewModel : INotifyPropertyChanged
    {
        CourseDTO course;
        public string Id {get; set;}
        public string Name {get; set;}
        public string Code {get; set;}
        public string AssignmentName {get; set;}
        public string AssignmentDescription {get; set;}
        public string DueDate {get; set;}
        public int Points {get; set;}
        
        public CourseDetailViewViewModel(string id) {
            course = new CourseDTO();
            Id = id ?? string.Empty;
            Name = string.Empty;
            Code = string.Empty;
            AssignmentName = string.Empty;
            AssignmentDescription = string.Empty;
            DueDate = string.Empty;
            Points = 0;
            if(!string.IsNullOrEmpty(id)){
                LoadById(id);
            }
        }
        public ObservableCollection<StudentDTO> Enrolled
        {
            get
            {
                if(string.IsNullOrEmpty(course.Id)){return new ObservableCollection<StudentDTO>();}
                return new ObservableCollection<StudentDTO>(StudentService.Current.Students.Where(s=> s.EnrolledCourses.Contains(course.Id)));
            }
        }
        public ObservableCollection<StudentDTO> NotEnrolled
        {
            get
            {
                return new ObservableCollection<StudentDTO>(StudentService.Current.Students.Except(Enrolled));
            }
        }
        public ObservableCollection<ModuleDTO> Modules
        {
            get
            {
                if(string.IsNullOrEmpty(course.Id)){return new ObservableCollection<ModuleDTO>();}
                return new ObservableCollection<ModuleDTO>(ModuleService.Current.Modules.Where(m=> m.CourseId == course.Id));
            }
        }
        public ObservableCollection<AssignmentDTO> Assignments
        {
            get
            {
                if(string.IsNullOrEmpty(course.Id)){return new ObservableCollection<AssignmentDTO>();}
                return new ObservableCollection<AssignmentDTO>(AssignmentService.Current.Assignments.Where(a=> a.CourseId == course.Id));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Course Functions
        public void LoadById(string id)
        {
            if(string.IsNullOrEmpty(id)) {return;}
            course = CourseService.Current.Courses.FirstOrDefault(c=> c.Id == id) ?? new CourseDTO();
            if(course != null)
            {
                Name = course.Name;
                Code = course.Code;
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(Code));
            }
        }
        public void AddCourse(Shell s)
        {
            course.Name = Name;
            course.Code = Code;
            CourseService.Current.AddOrUpdate(course);
            s.GoToAsync("//Instructor");
        }

        //Roster Functions
        public StudentDTO? SelectedStudent { get; set; }
        public void AddRoster(){
            if(SelectedStudent == null || SelectedStudent.EnrolledCourses.Contains(course.Id)){return;}
            SelectedStudent.EnrolledCourses.Add(course.Id);
            StudentService.Current.AddOrUpdate(SelectedStudent);
            RefreshView();
        }
        public void RemoveRoster(){
            if(SelectedStudent == null || !SelectedStudent.EnrolledCourses.Contains(course.Id)){return;}
            SelectedStudent.EnrolledCourses.Remove(course.Id);
            StudentService.Current.AddOrUpdate(SelectedStudent);
            RefreshView();
        }
        public ModuleDTO? SelectedModule {get;set;}
        public void RemoveModule(){
            if(SelectedModule != null){
                ModuleService.Current.Delete(SelectedModule.Id);
                RefreshView();
            }
        }
        public string EditModule(){
            return SelectedModule?.Id ?? string.Empty;
        }

        //Assignment Functions
        public AssignmentDTO? SelectedAssignment {get; set;}
        public void AddAssignment(){
            AssignmentDTO created = new AssignmentDTO{CourseId = course.Id, Name = AssignmentName, Description = AssignmentDescription, DueDate = DueDate, TotalPoints = Points};
            AssignmentService.Current.AddOrUpdate(created);
            RefreshView();
        }
        public void RemoveAssignment(){
            if(SelectedAssignment != null){
                AssignmentService.Current.Delete(SelectedAssignment.Id);
                RefreshView();
            }
        }

        //Refresh the screen
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(NotEnrolled));
            NotifyPropertyChanged(nameof(Enrolled));
            NotifyPropertyChanged(nameof(Modules));
            NotifyPropertyChanged(nameof(Assignments));
        }
    }
}

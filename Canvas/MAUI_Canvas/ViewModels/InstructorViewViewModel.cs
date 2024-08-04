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
    public class InstructorViewViewModel: INotifyPropertyChanged
    {
        public InstructorViewViewModel()
        {
            IsEnrollmentsVisible= true;
            IsCoursesVisible= false;
        }
        public ObservableCollection<StudentDTO> Students
        {
            get
            {
                return new ObservableCollection<StudentDTO>(StudentService.Current.Students);
            }
        }
        public ObservableCollection<CourseDTO> Courses
        {
            get
            {
                return new ObservableCollection<CourseDTO>(CourseService.Current.Courses);
            }
        }
        
        public bool IsEnrollmentsVisible
        {
            get; set;
        }
        public bool IsCoursesVisible
        {
            get; set;
        }
        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }
        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }
        private string? query;
        public string Query {
            get => query ?? string.Empty;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Students));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Selections
        public StudentDTO? SelectedStudent { get; set; }
        public CourseDTO? SelectedCourse { get; set; }

        //Enrollment Page
        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//StudentDetail?StudentId=0");
        }
        public void RemoveEnrollmentClick()
        {
            if(SelectedStudent == null) { return; }

            StudentService.Current.Delete(SelectedStudent.Id);
            RefreshView();
        }
        public void EditEnrollmentClick(Shell s)
        {
            if(SelectedStudent == null) { return; }
            string idParam = SelectedStudent.Id;
            s.GoToAsync($"//StudentDetail?StudentId={idParam}");
        }

        //Course Page
        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseDetail?CourseId=0");
        }
        public void EditCourseClick(Shell s)
        {
            if(SelectedCourse == null) { return; }
            string idParam = SelectedCourse.Id;
            s.GoToAsync($"//CourseDetail?CourseId={idParam}");
        }
        public void RemoveCourseClick()
        {
            if(SelectedCourse == null) { return; }
            CourseService.Current.Delete(SelectedCourse.Id);
            RefreshView();
        }

        //Refreshers
        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}

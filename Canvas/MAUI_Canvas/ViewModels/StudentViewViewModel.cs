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

namespace MAUI_Canvas.ViewModels;
internal class StudentViewViewModel: INotifyPropertyChanged
{
    public bool IsLoginVisible{get; set;}
    public bool IsStudentViewVisible{get; set;}
    public StudentViewViewModel(){
        IsLoginVisible= true;
        IsStudentViewVisible= false;
    }
    public ObservableCollection<StudentDTO> Students
    {
        get
        {
            return new ObservableCollection<StudentDTO>(StudentService.Current.Students);
        }
    }
    public ObservableCollection<CourseDTO> CoursesDetail
    {
        get
        {
            if(SelectedStudent?.EnrolledCourses == null){return new ObservableCollection<CourseDTO>();}
            return new ObservableCollection<CourseDTO>(CourseService.Current.Courses.Where(c=> SelectedStudent.EnrolledCourses.Exists(s=> s == c.Id)));
        }
    }
    public ObservableCollection<ModuleDTO> Modules
    {
        get
        {
            if(SelectedCourse == null){return new ObservableCollection<ModuleDTO>();}
            return new ObservableCollection<ModuleDTO>(ModuleService.Current.Modules.Where(m=> m.CourseId == SelectedCourse.Id));
        }
    }
    public ObservableCollection<AssignmentDTO> Assignments
    {
        get
        {
            if(SelectedCourse == null){return new ObservableCollection<AssignmentDTO>();}
            return new ObservableCollection<AssignmentDTO>(AssignmentService.Current.Assignments.Where(a=> a.CourseId == SelectedCourse.Id));
        }
    }
    

    public StudentDTO? SelectedStudent {get;set;}
    public CourseDTO? SelectedCourse{get; set;}

    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RefreshDetails(){
        NotifyPropertyChanged(nameof(Assignments));
        NotifyPropertyChanged(nameof(Modules));
    }

    public void Login(){
        if(SelectedStudent == null){return;}
        IsLoginVisible = false;
        IsStudentViewVisible = true;
        NotifyPropertyChanged(nameof(IsLoginVisible));
        NotifyPropertyChanged(nameof(IsStudentViewVisible));
        NotifyPropertyChanged(nameof(CoursesDetail));
        RefreshDetails();
    }
}

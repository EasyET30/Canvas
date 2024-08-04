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
    public class StudentDetailViewViewModel : INotifyPropertyChanged
    {
        public string name {get; set;}
        public string ClassificationString {get; set;}
        public string Id { get; set; }
        public StudentDTO student;

        public StudentDetailViewViewModel(string id) 
        {
            student = new StudentDTO();
            name = string.Empty;
            ClassificationString = "F";
            Id = id ?? string.Empty;
            if(!string.IsNullOrEmpty(id))
            {
                LoadById(id);
            }
        }

        public void LoadById(string id)
        {
            if(string.IsNullOrEmpty(id)) { return; }
            student = StudentService.Current.Students.FirstOrDefault(s=> s.Id == id) ?? new StudentDTO();
            if(student != null)
            {
                name = student.Name;
                Id = student.Id;
                ClassificationString = ClassToString(student.Classification);
            }
            
            NotifyPropertyChanged(nameof(name));
            NotifyPropertyChanged(nameof(ClassificationString));

        }

        public void AddPerson()
        {
            student.Name = name;
            student.Classification = StringToClass(ClassificationString);
            StudentService.Current.AddOrUpdate(student);

            Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StudentClassification StringToClass(string s)
        {
            StudentClassification classification;
            switch (s)
            {
                case "S":
                    classification = StudentClassification.Senior;
                    break;
                case "J":
                    classification = StudentClassification.Junior;
                    break;
                case "O":
                    classification = StudentClassification.Sophomore;
                    break;
                case "F":
                default:
                    classification = StudentClassification.Freshman;
                    break;
            }

            return classification;
        }

        private string ClassToString(StudentClassification pc)
        {
            string classificationString;
            switch (pc)
            {
                case StudentClassification.Senior:
                    classificationString = "S";
                    break;
                case StudentClassification.Junior:
                    classificationString = "J";
                    break;
                case StudentClassification.Sophomore:
                    classificationString = "O";
                    break;
                case StudentClassification.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;
        }
    }
}

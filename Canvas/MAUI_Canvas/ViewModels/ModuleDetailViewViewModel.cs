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
    class ModuleDetailViewViewModel : INotifyPropertyChanged
    {
        ModuleDTO LoadedModule;
        string Id {get;set;}
        string CourseId;
        public string Name {get; set;}
        public string Description {get; set;}
        public string ContentName {get; set;}
        public string ContentDescription {get; set;}
        public ModuleDetailViewViewModel(string courseId, string ModuleId){
            CourseId = courseId ?? string.Empty;
            LoadedModule = new ModuleDTO();
            Id = ModuleId ?? string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            ContentName = string.Empty;
            ContentDescription = string.Empty;
            if(!string.IsNullOrEmpty(ModuleId)){
                LoadById(ModuleId);
            }
            
        }
        public ObservableCollection<ContentItemDTO> Contents
        {
            get
            {
                return new ObservableCollection<ContentItemDTO>(ContentItemService.Current.ContentItems.Where(c => c.ModuleId == Id));
            }
        }
        
        public void LoadById(string ModuleId)
        {
            if(string.IsNullOrEmpty(ModuleId)) { return; }
            LoadedModule = ModuleService.Current.Modules.FirstOrDefault(m=>m.Id == ModuleId) ?? new ModuleDTO();
            if(LoadedModule != null)
            {
                Name = LoadedModule.Name;
                Description = LoadedModule.Description;
            }
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Contents));
        }

        public void AddModule(Shell s){
            LoadedModule.Name = Name;
            LoadedModule.Description = Description;
            LoadedModule.CourseId = CourseId;
            ModuleService.Current.AddOrUpdate(LoadedModule);

            s.GoToAsync($"//CourseDetail?CourseId={CourseId}");
        }

        public ContentItemDTO? SelectedContent { get; set; }
        public void AddContent(){
            ContentItemDTO created = new ContentItemDTO{ModuleId = LoadedModule.Id, Name = ContentName, Description = ContentDescription};
            ContentItemService.Current.AddOrUpdate(created);
            NotifyPropertyChanged(nameof(Contents));
        }
        public void RemoveContent(){
            if(SelectedContent != null){
                ContentItemService.Current.Delete(SelectedContent.Id);
                NotifyPropertyChanged(nameof(Contents));
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
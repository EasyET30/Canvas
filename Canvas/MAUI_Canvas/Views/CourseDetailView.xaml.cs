using MAUI_Canvas.ViewModels;
namespace MAUI_Canvas.Views;

[QueryProperty(nameof(CourseId), "CourseId")]
[QueryProperty(nameof(ModuleId), "ModuleId")]
public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
	}

    public string? CourseId{set; get;}
    public string? ModuleId{set; get;}
    private void CancelClicked(object sender, EventArgs e)
    {
      Shell.Current.GoToAsync("//Instructor");
    }
    private void OkClicked(object sender, EventArgs e)
    {
      (BindingContext as CourseDetailViewViewModel)?.AddCourse(Shell.Current);
    }
    
    //Roster Buttons
    private void AddToRoster(object sender, EventArgs e)
    {
		  (BindingContext as CourseDetailViewViewModel)?.AddRoster();
    }
    private void RemoveFromRoster(object sender, EventArgs e)
    {
		  (BindingContext as CourseDetailViewViewModel)?.RemoveRoster();
    }

    //Module Buttons
    private void AddModuleClicked(object sender, EventArgs e)
    {
      Shell.Current.GoToAsync($"//ModuleDetail?CourseId={CourseId}");
    }
    private void EditModuleClicked(object sender, EventArgs e)
    {
      ModuleId = (BindingContext as CourseDetailViewViewModel)?.EditModule() ?? string.Empty;
      Shell.Current.GoToAsync($"//ModuleDetail?CourseId={CourseId}&ModuleId={ModuleId}");
    }
    private void RemoveModuleClicked(object sender, EventArgs e)
    {
      (BindingContext as CourseDetailViewViewModel)?.RemoveModule();
    }

    //Assignment Buttons
    private void AddAssignmentClicked(object sender, EventArgs e)
    {
      (BindingContext as CourseDetailViewViewModel)?.AddAssignment();
    }
    private void RemoveAssignmentClicked(object sender, EventArgs e)
    {
      (BindingContext as CourseDetailViewViewModel)?.RemoveAssignment();
    }

    //Page Transfers
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		  BindingContext = null;
    }
	  private void OnArriving(object sender, NavigatedToEventArgs e) {
      BindingContext = new CourseDetailViewViewModel(CourseId ?? string.Empty);
    }
}
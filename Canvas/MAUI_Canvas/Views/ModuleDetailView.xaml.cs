using MAUI_Canvas.ViewModels;
namespace MAUI_Canvas.Views;

[QueryProperty(nameof(CourseId), "CourseId")]
[QueryProperty(nameof(ModuleId), "ModuleId")]
public partial class ModuleDetailView : ContentPage
{
	public string? ModuleId{set; get;}
	public string? CourseId{set; get;}
	public ModuleDetailView()
	{
		InitializeComponent();
    	//BindingContext = new ModuleDetailViewViewModel(CourseId, ModuleId);
	}

    //Page Transfers
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
	    BindingContext = null;
    }
	private void OnArriving(object sender, NavigatedToEventArgs e)
    {
    	BindingContext = new ModuleDetailViewViewModel(CourseId ?? string.Empty, ModuleId ?? string.Empty);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
    	Shell.Current.GoToAsync($"//CourseDetail?CourseId={CourseId}");
    }
    private void OkClicked(object sender, EventArgs e)
    {
    	(BindingContext as ModuleDetailViewViewModel)?.AddModule(Shell.Current);
    }

    //Content Buttons
    private void AddContentClicked(object sender, EventArgs e)
    {
    	(BindingContext as ModuleDetailViewViewModel)?.AddContent();
    }
    private void RemoveContentClicked(object sender, EventArgs e)
    {
    	(BindingContext as ModuleDetailViewViewModel)?.RemoveContent();
    }
  
}
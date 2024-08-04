
using MAUI_Canvas.ViewModels;

namespace MAUI_Canvas.Views;

[QueryProperty(nameof(StudentId), "StudentId")]
public partial class StudentDetailView : ContentPage
{
	public StudentDetailView()
	{
		InitializeComponent();
	}

    public string? StudentId{set; get;}

    private void OkClick(object sender, EventArgs e)
    {
		  (BindingContext as StudentDetailViewViewModel)?.AddPerson();
    }

    private void CancelClick(object sender, EventArgs e)
    {
      Shell.Current.GoToAsync("//Instructor");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		  BindingContext = null;
    }

	  private void OnArriving(object sender, NavigatedToEventArgs e) {
      BindingContext = new StudentDetailViewViewModel(StudentId ?? string.Empty);
    }
}
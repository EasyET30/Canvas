using MAUI_Canvas.ViewModels;
namespace MAUI_Canvas.Views;
public partial class StudentView : ContentPage
{
    public StudentView()
    {
        InitializeComponent();
        BindingContext = new StudentViewViewModel();
    }

    private void DetailsClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel)?.RefreshDetails();
    }

    private void LoginClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewViewModel)?.Login();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = null;
    }
	private void OnArriving(object sender, NavigatedToEventArgs e) {
      BindingContext = new StudentViewViewModel();
    }
}

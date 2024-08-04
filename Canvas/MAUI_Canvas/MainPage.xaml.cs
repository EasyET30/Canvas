namespace MAUI_Canvas;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		//BindingContext = new MainViewModel();
	}

	private void StudentViewClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Student");
	}

	private void InstructorViewClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Instructor");
	}
}
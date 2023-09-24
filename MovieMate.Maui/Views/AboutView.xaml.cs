using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class AboutView : ContentPage
{
	public AboutView(AboutViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class MovieEditView : ContentPage
{
	public MovieEditView(MovieEditViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}
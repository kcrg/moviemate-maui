using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class MovieDetailsView : ContentPage
{
	public MovieDetailsView(MovieDetailsViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}
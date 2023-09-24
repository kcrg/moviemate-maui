using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class MovieEditView
{
	public MovieEditView(MovieEditViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}
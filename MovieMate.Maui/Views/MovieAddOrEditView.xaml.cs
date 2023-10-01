using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class MovieAddOrEditView
{
	public MovieAddOrEditView(MovieAddOrEditViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}
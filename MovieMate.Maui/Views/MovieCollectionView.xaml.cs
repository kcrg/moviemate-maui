using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class MovieCollectionView
{
    public MovieCollectionView(MovieCollectionViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}
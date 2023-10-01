using CommunityToolkit.Mvvm.ComponentModel;
using MovieMate.Api.Models;
using MovieMate.Maui.ViewModels.Base;

namespace MovieMate.Maui.ViewModels;

public partial class MovieDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private MovieDto movie = new();

    public MovieDetailsViewModel()
    {
    }

    public override Task OnParameterSet()
    {
        if (NavigationParameter is MovieDto movie)
        {
            Movie = movie;
        }

        NavigationParameter = null;
        return base.OnParameterSet();
    }
}
using MovieMate.Api.Requests;
using MovieMate.Maui.ViewModels.Base;

namespace MovieMate.Maui.ViewModels;

public class MovieCollectionViewModel : BaseViewModel
{
    private readonly IMyMoviesApi myMoviesApi;

    public MovieCollectionViewModel(IMyMoviesApi myMoviesApi)
    {
        this.myMoviesApi = myMoviesApi;
    }
}
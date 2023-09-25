using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Api.Models;
using MovieMate.Api.Requests;
using MovieMate.Maui.Infrastructure;
using MovieMate.Maui.ViewModels.Base;
using MovieMate.Maui.Views;
using System.Collections.ObjectModel;

namespace MovieMate.Maui.ViewModels;

public partial class MovieCollectionViewModel : BaseViewModel
{
    private readonly IMyMoviesApi myMoviesApi;

    [ObservableProperty]
    string errorCode = "🥵🥵🥵";

    [ObservableProperty]
    private ObservableCollection<MovieDto> movieList;

    public MovieCollectionViewModel(IMyMoviesApi myMoviesApi)
    {
        this.myMoviesApi = myMoviesApi;
    }

    public override async Task Initialize()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        var result = await myMoviesApi.GetMyMovies();

        if (!result.IsSuccessStatusCode)
        {
            ErrorCode = result.StatusCode.ToString();
            CurrentState = StateKeys.Error;
            return;
        }

        await Task.Delay(1000);

        MovieList = new(result.Content);

        CurrentState = StateKeys.Success;
    }

    [RelayCommand]
    private async Task AddMovie()
    {
        await Navigation.NavigateTo($"/{nameof(MovieEditView)}");
    }
}
using CommunityToolkit.Maui.Layouts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Api.Models;
using MovieMate.Api.Requests;
using MovieMate.Maui.Infrastructure;
using MovieMate.Maui.Services;
using MovieMate.Maui.ViewModels.Base;
using MovieMate.Maui.Views;
using System.Collections.ObjectModel;

namespace MovieMate.Maui.ViewModels;

public partial class MovieCollectionViewModel : BaseViewModel
{
    private readonly IMyMoviesApi myMoviesApi;
    private readonly IMoviesDatabaseService moviesDatabaseService;

    [ObservableProperty]
    string errorCode = "🥵🥵🥵";

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    private ObservableCollection<MovieDto> movieList;

    public MovieCollectionViewModel(IMyMoviesApi myMoviesApi, IMoviesDatabaseService moviesDatabaseService)
    {
        this.myMoviesApi = myMoviesApi;
        this.moviesDatabaseService = moviesDatabaseService;
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
            ErrorCode = $"{result.StatusCode} ({(int)result.StatusCode})";
            CurrentState = StateKeys.Error;
            return;
        }

        foreach (var movieToSave in result.Content)
        {
            await moviesDatabaseService.SaveItemAsync(movieToSave);
        }

        var movieList = await moviesDatabaseService.GetItemsAsync();

        MovieList = new(movieList.OrderBy(x => x.Title));
        
        CurrentState = StateKeys.Success;
    }

    [RelayCommand]
    private async Task Refresh()
    {
        IsRefreshing = true;
        await LoadData();
        IsRefreshing = false;
    }

    [RelayCommand]
    private async Task AddMovie()
    {
        await Navigation.NavigateTo($"/{nameof(MovieEditView)}");
    }

    [RelayCommand]
    private async Task WipeList()
    {
        await moviesDatabaseService.WipeDatabaseAsync();
        MovieList.Clear();
    }

    public override async Task OnParameterSet()
    {
        if (NavigationParameter is MovieDto movieToSave)
        {
            await moviesDatabaseService.SaveItemAsync(movieToSave);
            MovieList?.Add(movieToSave);
        }

        NavigationParameter = null;
    }
}
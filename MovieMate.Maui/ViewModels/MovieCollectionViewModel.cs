using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Api.Models;
using MovieMate.Api.Requests;
using MovieMate.Maui.Infrastructure;
using MovieMate.Maui.Models;
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

        MovieList = [];
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

        // Change after some changes on backend :c
        if (result.Error is not null)
        {
            await Toast.Make($"{result.Error.Message}", ToastDuration.Long, 12).Show();
        }

        if (result.Content is not null)
        {
            foreach (var movieToSave in result.Content)
            {
                await moviesDatabaseService.SaveOrUpdateItemAsync(movieToSave);
            }
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
    private async Task ShowMovieDetails(MovieDto movie)
    {
        await Navigation.NavigateTo($"/{nameof(MovieDetailsView)}", movie);
    }

    [RelayCommand]
    private async Task AddMovie()
    {
        await Navigation.NavigateTo($"/{nameof(MovieAddOrEditView)}");
    }

    [RelayCommand]
    private async Task EditMovie(MovieDto movie)
    {
        var parameter = new MovieAddOrEditParameterModel
        {
            Movie = movie,
            IsCreatingNew = false
        };

        await Navigation.NavigateTo($"/{nameof(MovieAddOrEditView)}", parameter);
    }

    [RelayCommand]
    private async Task DeleteMovie(MovieDto movie)
    {
        MovieList.Remove(movie);
        await moviesDatabaseService.DeleteItemAsync(movie);
    }

    [RelayCommand]
    private async Task WipeList()
    {
        await moviesDatabaseService.WipeDatabaseAsync();
        MovieList.Clear();
    }

    public override async Task OnParameterSet()
    {
        if (NavigationParameter is MovieAddOrEditParameterModel parameter)
        {
            if (parameter.IsCreatingNew)
            {
                await moviesDatabaseService.SaveOrUpdateItemAsync(parameter.Movie);
                MovieList?.Add(parameter.Movie);
            }
            else
            {
                var item = MovieList.Where(i => i.LocalId == parameter.Movie.LocalId).First();
                var index = MovieList.IndexOf(parameter.Movie);

                if (index != -1)
                {
                    MovieList[index] = item;
                    await moviesDatabaseService.SaveOrUpdateItemAsync(parameter.Movie);
                }
            }
        }

        NavigationParameter = null;
    }
}
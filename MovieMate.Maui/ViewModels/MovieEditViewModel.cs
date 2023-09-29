using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Api.Models;
using MovieMate.Maui.ViewModels.Base;

namespace MovieMate.Maui.ViewModels;

public partial class MovieEditViewModel : BaseViewModel
{
    [ObservableProperty]
    private MovieDto movie;

    public MovieEditViewModel()
    {
        Movie = new()
        {
            Title = "Jan Paweł Drugi",
            Director = "Karol Wojtyła"
        };
    }

    [RelayCommand]
    private async Task Save()
    {
        await Navigation.NavigateTo("../", Movie);
    }

    [RelayCommand]
    private async Task Cancel()
    {
        await Navigation.NavigateTo("../");
    }
}
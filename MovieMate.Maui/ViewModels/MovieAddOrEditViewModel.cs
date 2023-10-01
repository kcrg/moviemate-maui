using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Api.Models;
using MovieMate.Maui.Models;
using MovieMate.Maui.ViewModels.Base;

namespace MovieMate.Maui.ViewModels;

public partial class MovieAddOrEditViewModel : BaseViewModel
{
    [ObservableProperty]
    private MovieDto movie = new();

    [ObservableProperty]
    private bool isValid;

    private bool IsCreatingNew = true;

    public MovieAddOrEditViewModel()
    {
    }

    [RelayCommand]
    private async Task Save()
    {
        if (!IsValid)
        {
            var toast = Toast.Make("Title is required, year must be between 1900 and 2200", ToastDuration.Long, 12);

            await toast.Show();
            return;
        }

        var parameter = new MovieAddOrEditParameterModel
        {
            Movie = Movie,
            IsCreatingNew = IsCreatingNew
        };

        await Navigation.NavigateTo("../", parameter);
    }

    [RelayCommand]
    private async Task Cancel()
    {
        await Navigation.NavigateTo("../");
    }

    public override Task OnParameterSet()
    {
        if (NavigationParameter is MovieAddOrEditParameterModel parameter)
        {
            if (parameter.Movie is null)
            {
                return base.OnParameterSet();
            }

            if (!parameter.IsCreatingNew)
            {
                Movie = parameter.Movie;
                IsCreatingNew = parameter.IsCreatingNew;
            }
        }

        NavigationParameter = null;
        return base.OnParameterSet();
    }
}
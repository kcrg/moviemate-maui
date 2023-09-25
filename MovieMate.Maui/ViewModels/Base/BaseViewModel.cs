using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Maui.Infrastructure;
using TinyMvvm;

namespace MovieMate.Maui.ViewModels.Base;

public partial class BaseViewModel : TinyViewModel
{
    [ObservableProperty]
    string currentState = StateKeys.Loading;

    public BaseViewModel() { }
}
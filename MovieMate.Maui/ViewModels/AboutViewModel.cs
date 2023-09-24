using CommunityToolkit.Mvvm.ComponentModel;
using MovieMate.Maui.ViewModels.Base;
using System.Reflection;

namespace MovieMate.Maui.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    private readonly IAppInfo appInfoService;

    [ObservableProperty]
    string? appVersion;

    [ObservableProperty]
    string? mauiVersion;

    public AboutViewModel(IAppInfo appInfoService)
    {
        this.appInfoService = appInfoService;

        var attr = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        int? index = attr?.LastIndexOf('+');
        attr = attr?.Substring(0, index ?? 0);

        MauiVersion = $".NET MAUI version: {attr}";
        AppVersion = $"Made using .NET MAUI with ♥ v{this.appInfoService.VersionString}.{this.appInfoService.BuildString}";
    }
}
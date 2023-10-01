using CommunityToolkit.Maui;
using MovieMate.Api;
using MovieMate.Maui.ViewModels;
using MovieMate.Maui.Views;
using TinyMvvm;
using MovieMate.Maui.Services;
using MovieMate.Maui.Services.Implementations;

#if DEBUG
using Microsoft.Extensions.Logging;
#endif

namespace MovieMate.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseTinyMvvm()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("tabler-icons.ttf", "IconFont");
                fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
                fonts.AddFont("Lato-Bold.ttf", "LatoBold");
                fonts.AddFont("Lato-Black.ttf", "LatoBlack");
            })
            .Services
            .RegisterViews()
            .RegisterViewModels()
            .RegisterServices()
            .RegisterMauiServices()
            .RegisterRefitApiServices()
            .RegisterApiServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddTransient<MovieCollectionView>();
        services.AddTransient<MovieDetailsView>();
        services.AddTransient<MovieAddOrEditView>();
        services.AddTransient<AboutView>();

        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<MovieCollectionViewModel>();
        services.AddTransient<MovieDetailsViewModel>();
        services.AddTransient<MovieAddOrEditViewModel>();
        services.AddTransient<AboutViewModel>();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IMessageDialogService, MessageDialogService>();
        services.AddSingleton<IMoviesDatabaseService, MoviesDatabaseService>();

        return services;
    }

    private static IServiceCollection RegisterMauiServices(this IServiceCollection services)
    {
        services.AddSingleton(AppInfo.Current);
        services.AddSingleton(Browser.Default);
        services.AddSingleton(Email.Default);
        services.AddSingleton(PhoneDialer.Default);

        return services;
    }
}

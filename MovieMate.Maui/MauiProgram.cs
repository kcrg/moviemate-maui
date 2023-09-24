using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MovieMate.Maui.ViewModels;
using MovieMate.Maui.Views;

namespace MovieMate.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
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
            .RegisterMauiServices();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddTransient<MovieCollectionView>();
        services.AddTransient<MovieDetailsView>();
        services.AddTransient<MovieEditView>();
        services.AddTransient<AboutView>();

        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<MovieCollectionViewModel>();
        services.AddTransient<MovieDetailsViewModel>();
        services.AddTransient<MovieEditViewModel>();
        services.AddTransient<AboutViewModel>();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
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

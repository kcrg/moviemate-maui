using MovieMate.Maui.Views;

namespace MovieMate.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(MovieDetailsView), typeof(MovieDetailsView));
        Routing.RegisterRoute(nameof(MovieAddOrEditView), typeof(MovieAddOrEditView));
    }
}

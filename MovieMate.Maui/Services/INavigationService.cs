namespace MovieMate.Maui.Services;

public interface INavigationService
{
    Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);

    Task PopAsync();
}

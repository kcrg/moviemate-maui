using MovieMate.Maui.ViewModels;

namespace MovieMate.Maui.Views;

public partial class AboutView : ContentPage
{
	public AboutView(AboutViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        MainThread.BeginInvokeOnMainThread(async () => await StartAnimationAsync());
    }

    private async Task StartAnimationAsync()
    {
        await Task.WhenAll(
           DescriptionPanel.TranslateTo(0, -15, 1000, Easing.CubicOut),
           DescriptionPanel.FadeTo(100, 1000, Easing.CubicIn),
           GithubButton.FadeTo(100, 1000, Easing.CubicIn));
    }
}
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieMate.Maui.ViewModels.Base;
using System.Reflection;

namespace MovieMate.Maui.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    private readonly IAppInfo appInfoService;
    private readonly IBrowser browserService;
    private readonly IEmail emailService;
    private readonly IPhoneDialer phoneDialerService;

    [ObservableProperty]
    string? appVersion, mauiVersion;

    [ObservableProperty]
    bool? showVersions;

    public AboutViewModel(IAppInfo appInfoService, IBrowser browserService, IEmail emailService, IPhoneDialer phoneDialerService)
    {
        this.appInfoService = appInfoService;
        this.browserService = browserService;
        this.emailService = emailService;
        this.phoneDialerService = phoneDialerService;
    }

    [RelayCommand]
    private void ShowMauiVersion()
    {
        var attr = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        int? index = attr?.LastIndexOf('+');
        attr = attr?.Substring(0, index ?? 0);

        AppVersion = $"Made using .NET MAUI with ♥ app v{appInfoService.VersionString}.{appInfoService.BuildString}";
        MauiVersion = $".NET MAUI version: {attr}";
        ShowVersions = true;
    }

    [RelayCommand]
    private async Task PhoneTapped()
    {
        try
        {
            phoneDialerService.Open("+48733428869");
        }
        catch (ArgumentNullException ex)
        {
            await ShowToastMessage("The phone number is incorrect.", ex.Source);
        }
        catch (FeatureNotSupportedException ex)
        {
            await ShowToastMessage("Device does not support phone calls or does not have phone app.", ex.Source);
        }
        catch (Exception ex)
        {
            await ShowToastMessage("An error occurred while opening the phone application.", ex.Source);
        }
    }

    [RelayCommand]
    private async Task EmailTapped()
    {
        try
        {
            await emailService.ComposeAsync(new EmailMessage(string.Empty, string.Empty, "kacper@tryniecki.com"));
        }
        catch (FeatureNotSupportedException ex)
        {
            await ShowToastMessage("Device does not support E-mail or does not have E-mail app.", ex.Source);
        }
        catch (Exception ex)
        {
            await ShowToastMessage("An error occurred while opening the email application.", ex.Source);
        }
    }

    [RelayCommand]
    private async Task OpenGithub()
    {
        await browserService.OpenAsync("https://github.com/kcrg", BrowserLaunchMode.SystemPreferred);
    }

    private async Task ShowToastMessage(string message, string? exceptionSource)
    {
        await Toast.Make($"{message} Src: {exceptionSource}", ToastDuration.Long, 12).Show();
    }
}
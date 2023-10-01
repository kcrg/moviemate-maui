namespace MovieMate.Maui.Services.Implementations;

public class MessageDialogService : IMessageDialogService
{
    public async Task<bool> ShowMessageDialog(string title, string message)
    {
        var currentPage = Application.Current?.MainPage;

        if (currentPage is null)
        {
            return false;
        }

        return await currentPage.DisplayAlert(title, message, "Yes", "Cancel");
    }
}
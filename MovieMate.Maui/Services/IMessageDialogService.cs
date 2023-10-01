namespace MovieMate.Maui.Services;

public interface IMessageDialogService
{
    Task<bool> ShowMessageDialog(string title, string message);
}
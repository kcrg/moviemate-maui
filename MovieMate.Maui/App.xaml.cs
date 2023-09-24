using TinyMvvm;

namespace MovieMate.Maui;

public partial class App : TinyApplication
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}

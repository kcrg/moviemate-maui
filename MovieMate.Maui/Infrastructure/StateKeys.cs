namespace MovieMate.Maui.Infrastructure;

//To hate IsBusy, that's how I was raised. ~KT
static class StateKeys
{
    public const string Refreshing = nameof(Refreshing);
    public const string Loading = nameof(Loading);
    //public const string Empty = nameof(Empty);
    public const string Success = nameof(Success);
    public const string Error = nameof(Error);
}

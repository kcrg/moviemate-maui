using MovieMate.Api.Models;

namespace MovieMate.Maui.Services;

public interface IMoviesDatabaseService
{
    Task<MovieDto> GetItemAsync(int id);
    Task<List<MovieDto>> GetItemsAsync();
    Task<int> SaveItemAsync(MovieDto item);
    Task<int> DeleteItemAsync(MovieDto item);
    Task<int> WipeDatabaseAsync();

}
using MovieMate.Api.Models;
using MovieMate.Api.Requests;
using MovieMate.Maui.Infrastructure;
using SQLite;

namespace MovieMate.Maui.Services.Implementations;

public class MoviesDatabaseService : IMoviesDatabaseService, IAsyncDisposable
{
    private SQLiteAsyncConnection? Database;

    public MoviesDatabaseService()
    {
    }

    private async Task Init()
    {
        if (Database is not null)
        {
            return;
        }

        Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        _ = await Database.CreateTableAsync<MovieDto>();
    }

    public async Task<List<MovieDto>> GetItemsAsync()
    {
        await Init();
        return await Database!.Table<MovieDto>().ToListAsync();
    }

    public async Task<MovieDto> GetItemAsync(int id)
    {
        await Init();
        return await Database!.Table<MovieDto>().Where(i => i.LocalId == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(MovieDto item)
    {
        await Init();

        if (item.RemoteId != 0)
        {
            var existingItem = await Database!.Table<MovieDto>().Where(i => i.RemoteId == item.RemoteId).FirstOrDefaultAsync();

            if (existingItem is not null)
            {
                item.RemoteId = existingItem.RemoteId;
                return await Database!.UpdateAsync(item);
            }
        }

        return await Database!.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(MovieDto item)
    {
        await Init();
        return await Database!.DeleteAsync(item);
    }

    public async Task<int> WipeDatabaseAsync()
    {
        await Init();
        return await Database!.DeleteAllAsync<MovieDto>();
    }

    public async ValueTask DisposeAsync()
    {
        if (Database is not null)
        {
            await Database.CloseAsync();
            Database = null;
        }
    }
}

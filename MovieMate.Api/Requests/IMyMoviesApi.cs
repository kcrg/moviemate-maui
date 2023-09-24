using MovieMate.Api.Models;
using Refit;

namespace MovieMate.Api.Requests;

public interface IMyMoviesApi
{
    [Get("/MyMovies")]
    Task<ApiResponse<List<MovieDto>>> GetMyMovies();
}

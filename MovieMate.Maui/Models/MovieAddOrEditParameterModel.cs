using MovieMate.Api.Models;

namespace MovieMate.Maui.Models;

public class MovieAddOrEditParameterModel
{
    public required MovieDto Movie { get; set; }
    public bool IsCreatingNew { get; set; }
}

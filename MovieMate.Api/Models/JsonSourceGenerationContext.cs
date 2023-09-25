using System.Text.Json.Serialization;

namespace MovieMate.Api.Models;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, 
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<MovieDto>))]
public partial class JsonSourceGenerationContext : JsonSerializerContext
{
}

using System.Text.Json.Serialization;

namespace MovieMate.Api.Models;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, DefaultIgnoreCondition = JsonIgnoreCondition.Never)]
[JsonSerializable(typeof(MovieDto))]
public partial class JsonSourceGenerationContext : JsonSerializerContext
{
}

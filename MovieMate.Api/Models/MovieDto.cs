using System.Text.Json.Serialization;

namespace MovieMate.Api.Models;

public class MovieDto
{
    [JsonPropertyName("id")]
    public int? Id;

    [JsonPropertyName("title")]
    public string? Title;

    [JsonPropertyName("director")]
    public string? Director;

    [JsonPropertyName("year")]
    public int? Year;

    [JsonPropertyName("rate")]
    public int? Rate;
}
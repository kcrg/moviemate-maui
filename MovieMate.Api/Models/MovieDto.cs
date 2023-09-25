using System.Text.Json.Serialization;

namespace MovieMate.Api.Models;

public class MovieDto
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("director")]
    public string? Director { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("rate")]
    public int? Rate { get; set; }
}
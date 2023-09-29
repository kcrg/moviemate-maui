using SQLite;
using System.Text.Json.Serialization;

namespace MovieMate.Api.Models;

public class MovieDto
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int LocalId { get; set; }

    [JsonPropertyName("id")]
    public int? RemoteId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("director")]
    public string? Director { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("rate")]
    public int? Rate { get; set; }
}
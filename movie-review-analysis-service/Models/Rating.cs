using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace movie_review_analysis_service.Models;

public class Rating
{
    [BsonElement("Source")]
    [JsonPropertyName("Source")]
    public string Source { get; set; } = null!;

    [BsonElement("Value")]
    [JsonPropertyName("Value")]
    public string Value { get; set; } = null!;
}

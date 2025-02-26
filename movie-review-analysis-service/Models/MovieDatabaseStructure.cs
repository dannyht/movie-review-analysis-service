using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace movie_review_analysis_service.Models;

[BsonIgnoreExtraElements]
public class MovieDatabaseStructure
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("movie")]
    [JsonPropertyName("Movie")]
    public Movie Movie { get; set; } = null!;
}

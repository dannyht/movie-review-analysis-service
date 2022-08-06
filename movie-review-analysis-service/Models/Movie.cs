using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace movie_review_analysis_service.Models
{
    public class Movie
    {
        [BsonElement("Title")]
        [JsonPropertyName("Title")]
        public string Title { get; set; } = null!;

        [BsonElement("Year")]
        [JsonPropertyName("Year")]
        public string Year { get; set; } = null!;

        [BsonElement("Rated")]
        [JsonPropertyName("Rated")]
        public string Rated { get; set; } = null!;

        [BsonElement("Released")]
        [JsonPropertyName("Released")]
        public string Released { get; set; } = null!;

        [BsonElement("Runtime")]
        [JsonPropertyName("Runtime")]
        public string Runtime { get; set; } = null!;

        [BsonElement("Genre")]
        [JsonPropertyName("Genre")]
        public string Genre { get; set; } = null!;

        [BsonElement("Director")]
        [JsonPropertyName("Director")]
        public string Director { get; set; } = null!;

        [BsonElement("Writer")]
        [JsonPropertyName("Writer")]
        public string Writer { get; set; } = null!;

        [BsonElement("Actors")]
        [JsonPropertyName("Actors")]
        public string Actors { get; set; } = null!;

        [BsonElement("Plot")]
        [JsonPropertyName("Plot")]
        public string Plot { get; set; } = null!;

        [BsonElement("Language")]
        [JsonPropertyName("Language")]
        public string Language { get; set; } = null!;

        [BsonElement("Country")]
        [JsonPropertyName("Country")]
        public string Country { get; set; } = null!;

        [BsonElement("Awards")]
        [JsonPropertyName("Awards")]
        public string Awards { get; set; } = null!;

        [BsonElement("Poster")]
        [JsonPropertyName("Poster")]
        public string Poster { get; set; } = null!;

        [BsonElement("Ratings")]
        [JsonPropertyName("Ratings")]
        public List<Rating> Ratings { get; set; } = null!;

        [BsonElement("Metascore")]
        [JsonPropertyName("Metascore")]
        public string Metascore { get; set; } = null!;

        [BsonElement("imdbRating")]
        [JsonPropertyName("imdbRating")]
        public string ImdbRating { get; set; } = null!;

        [BsonElement("imdbVotes")]
        [JsonPropertyName("imdbVotes")]
        public string ImdbVotes { get; set; } = null!;

        [BsonElement("imdbID")]
        [JsonPropertyName("imdbID")]
        public string ImdbID { get; set; } = null!;

        [BsonElement("Type")]
        [JsonPropertyName("Type")]
        public string Type { get; set; } = null!;

        [BsonElement("DVD")]
        [JsonPropertyName("DVD")]
        public string DVD { get; set; } = null!;

        [BsonElement("BoxOffice")]
        [JsonPropertyName("BoxOffice")]
        public string BoxOffice { get; set; } = null!;

        [BsonElement("Production")]
        [JsonPropertyName("Production")]
        public string Production { get; set; } = null!;

        [BsonElement("Website")]
        [JsonPropertyName("Website")]
        public string Website { get; set; } = null!;

        [BsonElement("Response")]
        [JsonPropertyName("Response")]
        public string Response { get; set; } = null!;
    }
}

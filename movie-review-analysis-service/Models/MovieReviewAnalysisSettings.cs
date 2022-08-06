namespace movie_review_analysis_service.Models
{
    public class MovieReviewAnalysisSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MoviesCollectionName { get; set; } = null!;
    }
}

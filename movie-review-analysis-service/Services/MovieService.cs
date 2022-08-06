using Microsoft.Extensions.Options;
using MongoDB.Driver;
using movie_review_analysis_service.Models;

namespace movie_review_analysis_service.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<MovieDatabaseStructure> _moviesCollection;

        public MovieService(
            IOptions<MovieReviewAnalysisSettings> movieReviewAnalysisSettings)
        {
            var settings = MongoClientSettings.FromConnectionString(
                movieReviewAnalysisSettings.Value.ConnectionString);

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(movieReviewAnalysisSettings.Value.DatabaseName);

            _moviesCollection = mongoDatabase.GetCollection<MovieDatabaseStructure>(
                movieReviewAnalysisSettings.Value.MoviesCollectionName);
        }

        public async Task<List<MovieDatabaseStructure>> GetAsync() =>
            await _moviesCollection.Find(_ => true).ToListAsync();

        public async Task<MovieDatabaseStructure?> GetAsync(string id) =>
            await _moviesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(MovieDatabaseStructure newMovie) =>
            await _moviesCollection.InsertOneAsync(newMovie);

        public async Task UpdateAsync(string id, MovieDatabaseStructure updatedMovie) =>
            await _moviesCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

        public async Task RemoveAsync(string id) =>
            await _moviesCollection.DeleteOneAsync(x => x.Id == id);
    }
}

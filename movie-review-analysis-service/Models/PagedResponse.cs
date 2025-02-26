namespace movie_review_analysis_service.Models;

internal class PagedResponse<T>
{
    public IEnumerable<MovieDatabaseStructure> Items { get; set; } = new List<MovieDatabaseStructure>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}

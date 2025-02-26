using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using movie_review_analysis_service.Models;
using movie_review_analysis_service.Services;

namespace movie_review_analysis_service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService) =>
        _movieService = movieService;

    [HttpGet("paged")]
    public async Task<IActionResult> GetPagedMovies([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        // Calculate how many records to skip
        var skip = (page - 1) * pageSize;

        // Query for all movies
        var query = await _movieService.GetAsync();

        // Count total documents
        var totalCount = query.Count;

        // Fetch the requested page
        var movies = query.Skip(skip).Take(pageSize);

        // Calculate total pages (ceiling)
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        // Package into a PagedResponse
        var response = new PagedResponse<Movie>
        {
            Items = movies,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = totalPages
        };

        return Ok(response);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MovieDatabaseStructure>> Get(string id)
    {
        var movie = await _movieService.GetAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        return movie;
    }

    // POST api/<MoviesController>
    [HttpPost]
    public async Task<IActionResult> Post(MovieDatabaseStructure newMovie)
    {
        await _movieService.CreateAsync(newMovie);

        return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, MovieDatabaseStructure updatedMovie)
    {
        var movie = await _movieService.GetAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        updatedMovie.Id = movie.Id;

        await _movieService.UpdateAsync(id, updatedMovie);

        return NoContent();
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var movie = await _movieService.GetAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        await _movieService.RemoveAsync(id);

        return NoContent();
    }
}

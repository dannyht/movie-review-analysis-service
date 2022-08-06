using Microsoft.AspNetCore.Mvc;
using movie_review_analysis_service.Models;
using movie_review_analysis_service.Services;

namespace movie_review_analysis_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService) =>
            _movieService = movieService;

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<List<MovieDatabaseStructure>> Get() =>
            await _movieService.GetAsync();

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
            var book = await _movieService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedMovie.Id = book.Id;

            await _movieService.UpdateAsync(id, updatedMovie);

            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _movieService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _movieService.RemoveAsync(id);

            return NoContent();
        }
    }
}

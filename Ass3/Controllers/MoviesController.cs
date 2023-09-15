using Ass3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        static List<Movie> movies = new List<Movie>
        {

            new Movie(){Id=1,MName="LoveToday",}
        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return movies;
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = movies.Find(t => t.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            movie.Id = movies.Count + 1;
            movies.Add(movie);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie updatedMovie)
        {
            var movie = movies.Find(t => t.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.MName = updatedMovie.MName;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = movies.Find(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            movies.Remove(movie);
            return NoContent();
        }
    }
}
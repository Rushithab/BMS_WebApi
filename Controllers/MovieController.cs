using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieServices _movieServices;

        public MovieController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpPost]
        public JsonResult Post(Movie movie)
        {
            _movieServices.Add(movie);
            return new JsonResult("Added Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var movie = _movieServices.Get(id);
            return new JsonResult(movie);
        }

        [HttpGet]
       public Task<IEnumerable<Movie>> Get()
        {
            return _movieServices.GetAll();
        }


        [HttpGet("category/{category}")]
        public JsonResult GetByCategory(string category)
        {
            var movie = _movieServices.GetByCategory(category);
            return new JsonResult(movie);
        }


        [HttpGet("genre/{genre}")]
        public JsonResult GetByGenre(string genre)
        {
            var movie = _movieServices.GetByGenre(genre);
            return new JsonResult(movie);
        }


        [HttpGet("name/{name}")]
        public JsonResult Get(string name)
        {
            var movie = _movieServices.GetByName(name);
            return new JsonResult(movie);
        }


        [HttpGet("actorName/{actorName}/actressName/{actressName}")]
        public JsonResult GetByStarNames(string actorName, string actressName)
        {
            var movie = _movieServices.GetByStarNames(actorName, actressName);
            return new JsonResult(movie);
        }

        [HttpPut]
        public JsonResult Put(Movie movie)
        {
            _movieServices.Update(movie);
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _movieServices.Delete(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}

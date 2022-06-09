using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private ITheatreServices _theatreServices;

        public TheatreController(ITheatreServices theatreServices)
        {
            _theatreServices = theatreServices;
        }

        [HttpPost]
        public JsonResult Post(Theatre theatre)
        {
            _theatreServices.Add(theatre);
            return new JsonResult("Added Successfully");
        }

        [HttpGet("id/{id}")]
        public JsonResult Get(int id)
        {
            var movie = _theatreServices.GetById(id);
            return new JsonResult(movie);
        }

        [HttpGet("city/{city}")]
        public JsonResult Get(string city)
        {
            var movie = _theatreServices.GetByCity(city);
            return new JsonResult(movie);
        }
        [HttpGet("moviename/{moviename}")]
        public JsonResult GetByMovieName(string moviename)
        {
            var theatre = _theatreServices.GetByMovieName(moviename);
            return new JsonResult(theatre);
        }

        [HttpGet]
        public Task<IEnumerable<Theatre>> Get()
        {
            return _theatreServices.GetAll();
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _theatreServices.Delete(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}

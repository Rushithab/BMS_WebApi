using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private ISeatServices _seatServices;

        public SeatController(ISeatServices seatServices)
        {
            _seatServices = seatServices;
        }

        [HttpPost]
        public JsonResult Post(Seat seat)
        {
            _seatServices.Add(seat);
            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        public List<Seat> Get()
        {
            return _seatServices.Get();
        }

        [HttpGet("showTime/{ShowTime}/movie/{MovieId}/theatre/{TheatreId}")]
        public JsonResult GetByMovieAndTheatre(string ShowTime, int MovieId, int TheatreId)
        {
            var movie = _seatServices.GetByShow(ShowTime, TheatreId, MovieId);
            return new JsonResult(movie);
        }

        [HttpPut("ticket/{ticketId}")]
        public JsonResult Put([FromRoute()] int ticketId, [FromBody()] Seat seat)
        {
            _seatServices.ChangeAvailability(ticketId, seat);
            return new JsonResult("Updated Successfully");
        }
    }
}

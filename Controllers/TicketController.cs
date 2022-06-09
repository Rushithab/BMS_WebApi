using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketServices _ticketServices;

        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpPost]
        public JsonResult Post(Ticket ticket)
        {
            _ticketServices.Add(ticket);
            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        public Task<IEnumerable<Ticket>> Get()
        {
            return _ticketServices.Get();
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var movie = _ticketServices.GetById(id);
            return new JsonResult(movie);
        }

        [HttpGet("userName/{userName}")]
        public JsonResult GetByUserName(string userName)
        {
            var movie = _ticketServices.GetByUserName(userName);
            return new JsonResult(movie);
        }
    }
}

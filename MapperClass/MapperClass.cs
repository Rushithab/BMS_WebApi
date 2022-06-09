using AutoMapper;
using BookMyShow.Models.CoreModels;
using BookMyShow.Models;
namespace BookMyShow.MapperClass
{
    public class MapperClass:Profile
    {
        public MapperClass()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Seat, SeatDTO>();
            CreateMap<Show, ShowDTO>();
            CreateMap<ShowMovieModel, ShowMovieModelDTO>();
            CreateMap<Theatre, TheatreDTO>();
            CreateMap<Ticket, TicketDTO>();

        }
    }
}

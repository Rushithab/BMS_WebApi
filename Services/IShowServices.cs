using BookMyShow.Data;
using BookMyShow.Models;
namespace BookMyShow.Services
{
    public interface IShowServices
    {
        public void Add(Show show);

        public List<Show> GetByTheatreId(int TheatreId);

        public List<Show> GetByMovieId(int MovieId);

        public List<Movie> GetByMovieAndCity(string MovieName, string City);

        public List<ShowMovieModel> GetShowByMovieAndCity(string MovieName, string City);

        public Show GetByMovieAndTheatre(int MovieId, int TheatreId);
    }
}

using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieServices
    {
        public Movie Add(Movie movie);

        public Movie Get(int id);

        public void Update(Movie movie);

        public void Delete(int id);
        Task<IEnumerable<Movie>> GetAll();  

        public List<Movie> GetByCategory(string Category);

        public List<Movie> GetByName(string Name);

        public List<Movie> GetByStarNames(string ActorName, string ActressName);

        public List<Movie> GetByGenre(string Genre);
    }
}

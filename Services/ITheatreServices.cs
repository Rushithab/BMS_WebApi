using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITheatreServices
    {
        public void Add(Theatre theatre);

        public Theatre GetById(int Id);

        public List<Theatre> GetByCity(string City);
        public List<Theatre> GetByMovieName(string MovieName);

        public void Delete(int Id);
        Task<IEnumerable<Theatre>> GetAll();

    }
}

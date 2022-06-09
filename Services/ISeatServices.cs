using BookMyShow.Models;
namespace BookMyShow.Services
{
    public interface ISeatServices
    {
        public void Add(Seat seat);

        public void ChangeAvailability(int ticketId, Seat seat);

        public List<Seat> Get();

        public List<Seat> GetByShow(string ShowTime, int theatreId, int MovieId);
    }
}

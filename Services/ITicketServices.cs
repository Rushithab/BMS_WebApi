using BookMyShow.Models;
namespace BookMyShow.Services
{
    public interface ITicketServices
    {
        public void Add(Ticket ticket);

        Task<IEnumerable<Ticket>> Get();

        public Ticket GetById(int Id);

        public Ticket GetByUserName(string UserName);
    }
}

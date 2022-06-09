using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Models.CoreModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace BookMyShow.Services
{
    public class TicketServices : ITicketServices
    {
        private IDbConnection _db;
        private readonly AutoMapper.IMapper _mapper;
        public TicketServices(AutoMapper.IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Ticket ticket)
        {
            var sqlQuery = "INSERT INTO Ticket (UserName,NumberOfSeats,ShowTime,TheatreId,MovieId) VALUES (@UserName,@NumberOfSeats,@ShowTime,@TheatreId,@MovieId)";
            _db.Execute(sqlQuery, ticket);
        }

        public async Task<IEnumerable<Ticket>> Get()
        {
            var ticketdto = _db.Query<Ticket>("SELECT * FROM Ticket").ToList();
            await Task.FromResult(_mapper.Map<IEnumerable<TicketDTO>>(ticketdto));
            return ticketdto;
        }

        public Ticket GetById(int id)
        {
            var sqlQuery = "SELECT * FROM Ticket where Id = @id";
            return _db.Query<Ticket>(sqlQuery, new { @Id = id }).Single();
        }

        public Ticket GetByUserName(string UserName)
        {
            var sqlQuery = "SELECT * FROM Ticket where UserName = @UserName";
            return _db.Query<Ticket>(sqlQuery, new { @UserName = UserName }).SingleOrDefault();
        }
    }
}
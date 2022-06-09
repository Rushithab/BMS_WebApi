using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Models.CoreModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace BookMyShow.Services
{
    public class SeatServices:ISeatServices
    {
        private IDbConnection _db;
        private readonly AutoMapper.IMapper _mapper;
        public SeatServices(AutoMapper.IMapper mapper,IConfiguration configuration)
        {
            _mapper = mapper;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Seat seat)
        {
            var sqlQuery = "INSERT INTO Seat (Number,ShowTime,TheatreId,MovieId,Availability) VALUES (@Number,@ShowTime,@TheatreId,@MovieId,@Availability)";
            _db.Execute(sqlQuery, seat);
        }
        public List<Seat> Get()
        {
            var seatdto = _db.Query<Seat>("SELECT * FROM Seat").ToList();
            Task.FromResult(_mapper.Map<IEnumerable<SeatDTO>>(seatdto));
            return seatdto;
        }

        public void ChangeAvailability(int ticketId, Seat seat)
        {
            seat.Availability = (seat.Availability == "Available") ? "Occupied" : "Available";
            var sqlQuery = "UPDATE Seat SET Number = @Number, ShowTime = @ShowTime, TheatreId = @TheatreId, MovieId = @MovieId,TicketId = @TicketId, Availability = @Availability where Number = @Number and ShowTime = @ShowTime and TheatreId = @TheatreId and MovieId = @MovieId";
            _db.Execute(sqlQuery, new { @Number = seat.Number, @ShowTime = seat.ShowTime, @TheatreId = seat.TheatreId, @MovieId = seat.MovieId, @Availability = seat.Availability, @TicketId = ticketId });
        }

        public List<Seat> GetByShow(string ShowTime, int theatreId, int MovieId)
        {
            var sqlQuery = "SELECT * FROM Seat where ShowTime = @ShowTime and TheatreId = @theatreId and MovieId = @MovieId";
            return _db.Query<Seat>(sqlQuery, new { @ShowTime = ShowTime, @TheatreId = theatreId, @MovieId = MovieId }).ToList();
        }
    }
}

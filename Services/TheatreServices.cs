using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Models.CoreModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace BookMyShow.Services
{
    public class TheatreServices:ITheatreServices
    {
        private IDbConnection _db;
        private readonly AutoMapper.IMapper _mapper;

        public TheatreServices(AutoMapper.IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Theatre theatre)
        {
            var sqlQuery = "INSERT INTO Theatre (Name,MovieName,City) VALUES (@Name,@MovieName,@City)";
            _db.Execute(sqlQuery, theatre);
        }

        public void Delete(int Id)
        {
            var sqlQuery = "DELETE FROM Theatre where Id = @Id";
            _db.Execute(sqlQuery, new { Id });
        }

        public async Task<IEnumerable<Theatre>> GetAll()
        {
            var theatredto = _db.Query<Theatre>("SELECT * FROM Theatre").ToList();
            await Task.FromResult(_mapper.Map<IEnumerable<TheatreDTO>>(theatredto));
            return theatredto;
        }

        public List<Theatre> GetByCity(string City)
        {
            var sqlQuery = "SELECT * FROM Theatre where City = @City";
            return _db.Query<Theatre>(sqlQuery, new { @City = City }).ToList();
        }
        public List<Theatre> GetByMovieName(string MovieName)
        {
            var sqlQuery = "SELECT * FROM Theatre where MovieName = @MovieName";
            return _db.Query<Theatre>(sqlQuery, new { @MovieName = MovieName }).ToList();
        }

        public Theatre GetById(int Id)
        {
            var sqlQuery = "SELECT * FROM Theatre where Id = @Id";
            return _db.Query<Theatre>(sqlQuery, new { @Id = Id }).SingleOrDefault();
        }
    }
}

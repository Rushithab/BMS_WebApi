using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Models.CoreModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShow.Services
{
    public class MovieServices:IMovieServices
    {
        private IDbConnection _db;
        private readonly AutoMapper.IMapper _mapper;
        public MovieServices(AutoMapper.IMapper mapper,IConfiguration configuration)
        {
            _mapper = mapper;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Movie Add(Movie movie)
        {
            var sqlQuery = "INSERT INTO Movie (Name,ImbdRating,Category,Genre,ReleaseDate,ActorName,ActressName) VALUES (@Name,@ImbdRating,@Category,@Genre,@ReleaseDate,@ActorName,@ActressName)";
            _db.Execute(sqlQuery, movie);
            return movie;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Movie where Id = @id";
            _db.Execute(sqlQuery, new { id });
        }

        public Movie Get(int id)
        {
            var sqlQuery = "SELECT * FROM Movie where Id = @id";
            return _db.Query<Movie>(sqlQuery, new { @Id = id }).Single();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var moviedto = _db.Query<Movie>("SELECT * FROM Movie").ToList();
            await Task.FromResult(_mapper.Map<IEnumerable<MovieDTO>>(moviedto));
            return moviedto;
        }

        public List<Movie> GetByCategory(string Category)
        {
            var sqlQuery = "SELECT * FROM Movie where Category = @Category";
            return _db.Query<Movie>(sqlQuery, new { @Category = Category }).ToList();
        }

        public List<Movie> GetByGenre(string Genre)
        {
            var sqlQuery = "SELECT * FROM Movie where Genre = @Genre";
            return _db.Query<Movie>(sqlQuery, new { @Genre = Genre }).ToList();
        }

        public List<Movie> GetByName(string Name)
        {
            var sqlQuery = "SELECT * FROM Movie where Name like @Name";
            return _db.Query<Movie>(sqlQuery, new { @Name = Name }).ToList();
        }

        public List<Movie> GetByStarNames(string ActorName, string ActressName)
        {
            var sqlQuery = "SELECT * FROM Movie where ActorName like @ActorName and ActressName like @ActressName";
            return _db.Query<Movie>(sqlQuery, new { @ActorName = ActorName, @ActressName = ActressName }).ToList();
        }

        public void Update(Movie movie)
        {
            var sqlQuery = "UPDATE Movie SET Name = @Name, ImbdRating = @ImbdRating, Category = @Category, Genre = @Genre, ReleaseDate = @ReleaseDate, ActorName = @ActorName, ActressName = @ActressName where Id = @Id";
            _db.Execute(sqlQuery, movie);
        }
    }
}

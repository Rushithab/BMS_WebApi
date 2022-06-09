using BookMyShow.Data;
using System.ComponentModel.DataAnnotations;
namespace BookMyShow.Models.CoreModels
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ImbdRating { get; set; }

        public string Category { get; set; }

        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string ActorName { get; set; }

        public string ActressName { get; set; }
    }
}

using BookMyShow.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models
{
    public class Show
    {
        public string Time { get; set; }

        // Data annotation 
        [ForeignKeyAttribute("Theatre")]
        public int TheatreId { get; set; }

        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }
    }
}

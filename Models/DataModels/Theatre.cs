using BookMyShow.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookMyShow.Models
{
    public class Theatre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [ForeignKeyAttribute("Movie")]
        public string MovieName { get; set; }

        [EnumDataType(typeof(City))]
        public string City { get; set; }

    }
}

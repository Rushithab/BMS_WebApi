namespace BookMyShow.Models.CoreModels
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int NumberOfSeats { get; set; }
        public string ShowTime { get; set; }
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
    }
}

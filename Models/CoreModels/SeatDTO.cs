namespace BookMyShow.Models.CoreModels
{
    public class SeatDTO
    {
        public int Number { get; set; }
        public string ShowTime { get; set; }
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
        public int TicketId { get; set; }
        public string Availability { get; set; }
    }
}

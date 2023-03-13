namespace Cinema.Shared.DTO
{
    public class SeatDTO
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        
        public bool DisabiltySeat { get; set; }

        public int? RoomID { get; set; }
        public RoomDTO? Room { get; set; }

        public List<SeatScreeningDTO>? SeatScreenings { get; set; }
    }
}

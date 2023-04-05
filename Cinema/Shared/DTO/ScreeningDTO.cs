namespace Cinema.Shared.DTO
{
    public class ScreeningDTO
    {
        public Guid ID { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }
    }
}

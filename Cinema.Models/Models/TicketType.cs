﻿namespace Cinema.Models.Models
{
    public class TicketType
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public List<TicketTypeBooking>? TicketTypeBookings { get; set; }
    }
}

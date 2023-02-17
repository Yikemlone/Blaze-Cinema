using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public List<SeatDTO> Seats { get; set; }
        public List<TicketTypeDTO> TicketTypes { get; set; }
        public CustomerDTO? Customer { get; set; }

    }
}

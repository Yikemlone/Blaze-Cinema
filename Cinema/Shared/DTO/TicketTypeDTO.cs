using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class TicketTypeDTO
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}

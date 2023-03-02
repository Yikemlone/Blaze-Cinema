using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Shared.DTO
{
    public class ScreeningDTO
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }
    }
}

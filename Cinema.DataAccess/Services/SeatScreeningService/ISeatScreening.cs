using Cinema.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Services.ScreeningService
{
    public interface ISeatScreening
    {
        public Task<SeatScreeningDTO> GetSeatScreening();
        public Task UpdateSeatScreening(SeatScreeningDTO seatScreening);

    }
}

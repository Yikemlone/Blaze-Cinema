using Cinema.DataAccess.Context;
using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.SeatScreeningServices
{
    public class SeatScreeningService : ISeatScreeningService
    {
        private readonly CinemaDBContext _context;

        public SeatScreeningService(CinemaDBContext context)
        {
            _context = context;
        }

        public async Task<List<SeatScreeningDTO>> GetAllAsync(int screeningID)
        {
            var seatScreenings = _context.SeatScreenings
                .Where(sc => sc.ScreeningID == screeningID)
                .Select(sc => new SeatScreeningDTO()
                {
                    ID = sc.ID,
                    Booked = sc.Booked,
                    Seat = (_context.Seats
                        .Where(s => s.ID == sc.SeatID)
                        .Select(s => new SeatDTO
                        {
                            ID = s.ID,
                            SeatNumber = s.SeatNumber,
                            RoomID = s.RoomID,
                            DisabiltySeat = s.DisabiltySeat,
                        })
                        .FirstOrDefault()
                    ),
                    BookingID = sc.BookingID,
                    ScreeningID = sc.ScreeningID
                })
                .ToList();

            return seatScreenings;
        }

        public async Task<SeatScreeningDTO> GetAsync(int seatScreeningID)
        {
            var SeatScreening = _context.SeatScreenings
                .Where(sc => sc.ID == seatScreeningID)
                .Select(sc => new SeatScreeningDTO()
                {
                    ID = sc.ID,
                    Booked = sc.Booked,
                    Seat = (_context.Seats
                        .Where(s => s.ID == sc.SeatID)
                        .Select(s => new SeatDTO
                        {
                            ID = s.ID,
                            SeatNumber = s.SeatNumber,
                            RoomID = s.RoomID,
                            DisabiltySeat = s.DisabiltySeat,
                        })
                        .FirstOrDefault()
                    ),
                    BookingID = sc.BookingID,
                    ScreeningID = sc.ScreeningID
                })
                .SingleOrDefault();

            return SeatScreening;
        }

        public async Task UpdateAsync(SeatScreeningDTO seatScreening)
        {
            var oldSeatScreening = _context.SeatScreenings
                .Where(sc => sc.ID == seatScreening.ID)
                .Select(s => s)
                .SingleOrDefault();

            if (oldSeatScreening == null) return;
            oldSeatScreening.Booked = seatScreening.Booked;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAllAsync(List<SeatScreeningDTO> seatsScreening)
        {
            foreach (var seatScreening in seatsScreening)
            {
                var oldSeatScreening = _context.SeatScreenings
                    .Where(sc => sc.ID == seatScreening.ID)
                    .Select(s => s)
                    .SingleOrDefault();

                if (oldSeatScreening == null) return;
                oldSeatScreening.Booked = seatScreening.Booked;
            }

            await _context.SaveChangesAsync();
        }
    }
}

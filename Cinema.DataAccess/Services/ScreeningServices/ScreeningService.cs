using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.ScreeningServices
{
    public class ScreeningService : IScreeningService
    {
        private readonly CinemaDBContext _context;

        public ScreeningService(CinemaDBContext context)
        {
            _context = context;
        }

        public async Task<List<ScreeningDTO>> GetAllAsync()
        {
            var Screenings = _context.Screenings
                .Select(m => new ScreeningDTO()
                {
                    ID = m.ID,
                    MovieID = m.MovieID,
                    RoomID = m.RoomID,
                    DateTime = m.DateTime
                })
                .ToList();

            return Screenings;
        }

        public async Task<ScreeningDTO> GetAsync(int screeningID)
        {
            var Screening = _context.Screenings
                .Where(m => m.ID == screeningID)
                .Select(m => new ScreeningDTO()
                {
                    ID = m.ID,
                    MovieID = m.MovieID,
                    RoomID = m.RoomID,
                    DateTime = m.DateTime

                })
                .SingleOrDefault();

            return Screening;
        }

        public async Task AddAsync(ScreeningDTO screening)
        {
            var newScreening = new Screening()
            {
                DateTime = screening.DateTime,
                MovieID = screening.MovieID,
                RoomID = screening.RoomID
            };

            await _context.AddAsync(newScreening);
            await _context.SaveChangesAsync();

            var seats = await _context.Seats
                .Where(s => s.RoomID == newScreening.RoomID)
                .Select(s => s)
                .ToListAsync();

            var screeningSeats = new List<SeatScreening>();

            foreach (var seat in seats)
            {
                screeningSeats.Add(new SeatScreening
                {
                    ScreeningID = newScreening.ID,
                    Booked = false,
                    SeatID = seat.ID
                });
            }

            await _context.AddRangeAsync(screeningSeats);
        }

        public async Task UpdateAsync(ScreeningDTO screening)
        {
            var oldScreening = await _context.Screenings
                .Where(m => m.ID == screening.ID)
                .Select(m => m)
                .FirstOrDefaultAsync();

            if (oldScreening == null) return;

            oldScreening.DateTime = screening.DateTime;
            oldScreening.MovieID = screening.MovieID;
            oldScreening.RoomID = screening.RoomID;

            var seats = await _context.Seats
                .Where(s => s.RoomID == screening.RoomID)
                .Select(s => s)
                .ToListAsync();

            var newScreeningSeats = new List<SeatScreening>();

            foreach (var seat in seats)
            {
                newScreeningSeats.Add(new SeatScreening
                {
                    Booked = false,
                    ScreeningID = screening.ID,
                    SeatID = seat.ID,
                });
            }

            var oldScreeningsSeats = await _context.SeatScreenings
                .Where(s => s.ScreeningID == screening.ID)
            .Select(s => s)
                .ToListAsync();

            _context.SeatScreenings.RemoveRange(oldScreeningsSeats);
        }

        public async Task DeleteAsync(ScreeningDTO screening)
        {
            var screeningToDelete = await _context.Screenings
                .Where(m => m.ID == screening.ID)
                .Select(s => s)
            .FirstOrDefaultAsync();

            if (screening == null) return;

            var seatScreenings = await _context.SeatScreenings
                .Where(s => s.ScreeningID == screeningToDelete.ID)
            .Select(s => s)
            .ToListAsync();

            _context.Screenings.Remove(screeningToDelete);
            _context.SeatScreenings.RemoveRange(seatScreenings);
        }
    }
}

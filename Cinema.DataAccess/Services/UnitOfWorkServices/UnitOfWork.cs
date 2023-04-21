using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.MovieServices;
using Cinema.DataAccess.Services.RoomsServices;
using Cinema.DataAccess.Services.ScreeningServices;
using Cinema.DataAccess.Services.SeatScreeningServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMovieService MovieService { get; private set; }
        public IBookingService BookingService { get; private set; }
        public ICustomerService CustomerService { get; private set; }
        public IRoomsService RoomsService { get; private set; }
        public IScreeningService ScreeningService { get; private set; }
        public ISeatScreeningService SeatScreeningService { get; private set; }

        private readonly CinemaDBContext _context;

        public UnitOfWork(CinemaDBContext context) 
        {
            _context = context;
            MovieService = new MovieService(_context);
            BookingService = new BookingService(_context);
            RoomsService = new RoomService(_context);
            ScreeningService = new ScreeningService(_context);
            SeatScreeningService = new SeatScreeningService(_context);
            //CustomerService = new CustomerService(_context);
        }

        public void Dispose()
        {
             _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

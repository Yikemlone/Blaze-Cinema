using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.MovieServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMovieService MovieService { get; private set; }
        public IBookingService BookingService { get; private set; }
        public ICustomerService CustomerService { get; private set; }

        private readonly CinemaDBContext _context;

        public UnitOfWork(CinemaDBContext context) 
        {
            _context = context;
            MovieService = new MovieService(_context);
            BookingService = new BookingService(_context);
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

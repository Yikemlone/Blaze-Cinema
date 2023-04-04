using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.AdminServices;
using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.ManagerServices;
using Cinema.DataAccess.Services.MovieServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMovieService MovieService { get; private set; }
        public IManagerService ManagerService { get; private set; }
        public IBookingService BookingService { get; private set; }
        public IAdminService AdminService { get; private set; }
        public ICustomerService CustomerService { get; private set; }

        private readonly CinemaDBContext _context;

        public UnitOfWork(CinemaDBContext context) 
        {
            _context = context;
            MovieService = new MovieService(_context);
            ManagerService = new ManagerService(_context);
            BookingService = new BookingService(_context);
            AdminService = new AdminService(_context);
            //CustomerService = new CustomerService(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

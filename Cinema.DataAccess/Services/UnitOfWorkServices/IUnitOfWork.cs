using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.MovieServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieService MovieService { get; }
        IBookingService BookingService { get; }
        ICustomerService CustomerService { get; }

        Task SaveAsync();
    }
}

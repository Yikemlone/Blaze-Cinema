using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.MovieServices;
using Cinema.DataAccess.Services.RoomsServices;
using Cinema.DataAccess.Services.ScreeningServices;
using Cinema.DataAccess.Services.SeatScreeningServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingService BookingService { get; }
        ICustomerService CustomerService { get; }
        IMovieService MovieService { get; }
        IRoomsService RoomsService { get; }
        IScreeningService ScreeningService { get; }
        ISeatScreeningService SeatScreeningService { get; }

        Task SaveAsync();
    }
}

using Cinema.DataAccess.Services.AdminServices;
using Cinema.DataAccess.Services.BookingServices;
using Cinema.DataAccess.Services.CustomerServices;
using Cinema.DataAccess.Services.ManagerServices;
using Cinema.DataAccess.Services.MovieServices;

namespace Cinema.DataAccess.Services.UnitOfWorkServices
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieService MovieService { get; }
        IManagerService ManagerService { get; }
        IBookingService BookingService { get; }
        IAdminService AdminService { get; }
        ICustomerService CustomerService { get; }

        Task SaveAsync();
    }
}

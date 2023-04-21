using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BookingController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork bookingService)
        {
            _unitOfWork = bookingService;
        }

        [HttpGet]
        [Authorize(Policy = "IsManager")]
        [Route("bookings")]
        public async Task<List<BookingDTO>> GetBookings()
        {
            return await _unitOfWork.BookingService.GetAllAsync();
        }

        [HttpGet]
        [Authorize(Policy = "IsCustomer")]
        [Route("bookings/{customerID}")]
        public async Task<List<BookingDTO>> GetCustomerBookings(int customerID)
        {
            return await _unitOfWork.BookingService.GetAsync(customerID);
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO) 
        {
            await _unitOfWork.BookingService.AddAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Authorize(Policy = "IsCustomer")]
        [Route("update")]
        public async Task UpdateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO)
        {
            await _unitOfWork.BookingService.UpdateAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Authorize(Policy = "IsCustomer")]
        [Route("delete")]
        public async Task DeleteBooking([FromBody] int bookingID)
        {
            await _unitOfWork.BookingService.DeleteAsync(bookingID);
            await _unitOfWork.SaveAsync();
        }
    }
}

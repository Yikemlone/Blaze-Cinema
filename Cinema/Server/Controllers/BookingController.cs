using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    // This whole contorller should be authed, except for create booking
    [ApiController]
    [Route("/api/[controller]")]
    public class BookingController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork bookingService)
        {
            _unitOfWork = bookingService;
        }

        // Gets
        [HttpGet]
        [Route("bookings")]
        public async Task<List<BookingDTO>> GetBookings()
        {
            return await _unitOfWork.BookingService.GetBookingsAsync();
        }

        [HttpGet]
        [Route("bookings/{customerID}")]
        public async Task<List<BookingDTO>> GetCustomerBookings(int customerID)
        {
            return await _unitOfWork.BookingService.GetCustomerBookingsAsync(customerID);
        }


        // Create, Update and Delete
        [HttpPost]
        [Route("create")]
        public async Task CreateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO) 
        {
            await _unitOfWork.BookingService.CreateBookingAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO)
        {
            await _unitOfWork.BookingService.UpdateBookingAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("delete/{bookingID}")]
        public async Task DeleteBooking(int bookingID)
        {
            await _unitOfWork.BookingService.DeleteBookingAsync(bookingID);
            await _unitOfWork.SaveAsync();
        }
    }
}

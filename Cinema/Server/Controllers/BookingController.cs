using Cinema.DataAccess.Services.BookingService;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BookingController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // Gets
        [HttpGet]
        [Route("bookings")]
        public async Task<List<BookingDTO>> GetBookings()
        {
            return await _bookingService.GetBookingsAsync();
        }

        [Authorize(Policy = "IsCustomer")]
        [HttpGet]
        [Route("bookings/{customerID}")]
        public async Task<List<BookingDTO>> GetCustomerBookings(int customerID)
        {
            return await _bookingService.GetCustomerBookingsAsync(customerID);
        }


        // Create, Update and Delete
        [HttpPost]
        [Route("create")]
        public async Task CreateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO) 
        {
            await _bookingService.CreateBookingAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
        }

        [Authorize(Policy = "IsCustomer")]
        [HttpPost]
        [Route("update")]
        public async Task UpdateBooking([FromBody] BookingAndSeatDTO bookingAndSeatDTO)
        {
            await _bookingService.UpdateBookingAsync(bookingAndSeatDTO.BookingDTO, bookingAndSeatDTO.TicketTypeBookingDTO);
        }

        [Authorize(Policy = "IsCustomer")]
        [HttpPost]
        [Route("delete/{bookingID}")]
        public async Task DeleteBooking(int bookingID)
        {
           await _bookingService.DeleteBookingAsync(bookingID);
        }
    }
}

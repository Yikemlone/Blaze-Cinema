using Cinema.DataAccess.Services.EmailServices;
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
        private readonly IEmailService _emailService;

        public BookingController(IUnitOfWork bookingService, IEmailService emailService)
        {
            _unitOfWork = bookingService;
            _emailService = emailService;
        }

        [HttpGet]
        [Authorize(Policy = "IsManager")]
        [Route("bookings")]
        public async Task<List<BookingDTO>> GetBookingsAsync()
        {
            return await _unitOfWork.BookingService.GetAllAsync();
        }

        [HttpGet]
        [Authorize(Policy = "IsCustomer")]
        [Route("bookings")]
        public async Task<List<BookingDTO>> GetCustomerBookingsAsync([FromBody] Guid customerID)
        {
            return await _unitOfWork.BookingService.GetAsync(customerID);
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateBookingAsync([FromBody] ConfirmBookingDTO confirmbooking) 
        {
            await _unitOfWork.BookingService.AddAsync(confirmbooking.BookingDTO, confirmbooking.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
            await _emailService.SendEmail(confirmbooking.BookingDTO, confirmbooking.ScreeningDTO, 
                confirmbooking.Movie, confirmbooking.Total, confirmbooking.Email);
        }

        [HttpPost]
        [Authorize(Policy = "IsCustomer")]
        [Route("update")]
        public async Task UpdateBookingAsync([FromBody] ConfirmBookingDTO confirmbooking)
        {
            await _unitOfWork.BookingService.UpdateAsync(confirmbooking.BookingDTO, confirmbooking.TicketTypeBookingDTO);
            await _unitOfWork.SaveAsync();
            await _emailService.SendEmail(confirmbooking.BookingDTO, confirmbooking.ScreeningDTO,
                confirmbooking.Movie, confirmbooking.Total, confirmbooking.Email);
        }

        [HttpPost]
        [Authorize(Policy = "IsCustomer")]
        [Route("delete")]
        public async Task DeleteBookingAsync([FromBody] int bookingID)
        {
            await _unitOfWork.BookingService.DeleteAsync(bookingID);
            await _unitOfWork.SaveAsync();
        }


        [HttpGet]
        [Route("tickets")]
        public async Task<List<TicketTypeDTO>> GetTicketsAsync()
        {
            return await _unitOfWork.BookingService.GetTicketTypesAsync();
        }
    }
}

using Cinema.Models.Models;
using Cinema.Shared.DTO;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;

namespace Cinema.DataAccess.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(BookingDTO booking, ScreeningDTO screening, string movie, decimal total, string toEmail)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
                //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //PickupDirectoryLocation = @"C:\EmailTests"
            });

            string seatNumbers = "";

            foreach(var seat in booking.SeatScreenings)
            {
                seatNumbers += seat.Seat.SeatNumber + " ";
            }

            StringBuilder template = new();
            template.AppendLine("Hello there!");
            template.AppendLine("");
            template.AppendLine("Thanks for booking with Blaze Cinema! Here is your booking details:");
            template.AppendLine("");
            template.AppendLine($"- Booking reference: {booking.BookingRef}");
            template.AppendLine($"- Movie: {movie}");
            template.AppendLine($"- Date: {screening.DateTime.ToString()}");
            template.AppendLine($"- Room: {screening.RoomID}");
            template.AppendLine($"- Seat Qty: {booking.SeatScreenings.Count}");
            template.AppendLine($"- Seat Numbers: {seatNumbers}");
            template.AppendLine($"- Total: {total}");
            template.AppendLine("");
            template.AppendLine("- Blaze Cinema");

            Email.DefaultSender = sender;

            var email = await Email
                .From("blazeCinema@blaze.com")
                .To(toEmail, toEmail)
                .Subject("Booking Confirmation")
                .Body(template.ToString())
                .SendAsync();
        }
    }
}

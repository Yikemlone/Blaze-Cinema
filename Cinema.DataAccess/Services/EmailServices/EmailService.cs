using Cinema.Shared.DTO;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;

namespace Cinema.DataAccess.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(BookingDTO booking, string toEmail)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
                //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //PickupDirectoryLocation = @"C:\EmailTests"
            });

            StringBuilder template = new();
            template.AppendLine("Hey there!");
            template.AppendLine("<p>Thanks for booking with Blaze Cinema! Here is your booking details.</p>");
            template.AppendLine("<ul><li>@Model.BookingRef</li><ul>");
            template.AppendLine("- Blaze Cinema");

            Email.DefaultSender = sender;

            var email = await Email
                .From("blazeCinema@blaze.com")
                .To(toEmail, toEmail)
                .Subject("Booking Confirmation")
                .UsingTemplate(template.ToString(), booking)
                .SendAsync();
        }
    }
}

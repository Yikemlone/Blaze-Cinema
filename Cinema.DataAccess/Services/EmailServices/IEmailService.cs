using Cinema.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Services.EmailServices
{
    public interface IEmailService
    {
        public Task SendEmail(BookingDTO booking, string toEmail);
    }
}

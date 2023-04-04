using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;


namespace Cinema.DataAccess.Services.EmailService
{
    public interface IEmailService
    {
        public Task SendEmail();
    }

}


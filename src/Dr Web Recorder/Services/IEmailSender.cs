using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dr_Web_Recorder.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

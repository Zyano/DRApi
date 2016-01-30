using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dr_Web_Recorder.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Api.Core.Services.Interfaces
{
    public interface ISmtpService
    {
        Task SendAsync(string emailTo, string body, string chanel);
    }
}

using NotificationService.Api.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace NotificationService.Api.Core.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly ILogger<SmtpService> _logger;
        private readonly IConfiguration _configuration;

        public SmtpService(ILogger<SmtpService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        private async Task SendAsync(string emailTo, string body, SmtpClient smtp, string title)
        {
            string emailFrom = _configuration["login"];

            var mail = new MailMessage();
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = title;
            mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, null, "text/html"));

            try
            {
                await smtp.SendMailAsync(mail);
                _logger.LogInformation($"Sent email to {emailTo}");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error to send email to {emailTo}", e);
            }
        }

        public async Task SendAsync(string[] emailsTo, string body, string title)
        {
            using (SmtpClient smtp = GetSmtpClient())
            {
                smtp.UseDefaultCredentials = true;
                foreach (var email in emailsTo)
                {
                    await SendAsync(email, body, smtp, title);
                }
            }
        }

        public async Task SendAsync(string emailTo, string body, string title)
        {
            await SendAsync(new[] { emailTo }, body, title);
        }

        private SmtpClient GetSmtpClient()
        {
            //int portNumber = 587;
            //int.TryParse(_configuration["port"], out portNumber);
            //string smtpAddress = _configuration["smtpHostAddress"];
            //return new SmtpClient(smtpAddress, portNumber);

            var client =  new SmtpClient
            {
                Host = _configuration["smtpHostAddress"],
                Port = int.Parse(_configuration["port"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_configuration["login"], _configuration["password"])
            };
            return client;
        }

    }
}

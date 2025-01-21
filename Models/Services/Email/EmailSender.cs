
using System.Net.Mail;

namespace ExpanseTracker.Models.Services.Email
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender          // inject IConfiguration _configuration to use data from appsettings.json after the program has been started
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = _configuration["EmailSettings:DefaultEmailAdress"];
            var smtpServer = _configuration["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(smtpServer,smtpPort);

            await client.SendMailAsync(message);
        }
    }
}

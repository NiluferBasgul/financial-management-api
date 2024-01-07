using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace financial_management_api.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _emailFrom;
        private readonly string _password;
        private readonly ILogger _logger;
        private readonly EmailSettings _emailSettings;


        public EmailSender(string emailFrom, string password)
        {
            _emailFrom = emailFrom;
            _password = password;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var message = new MailMessage(_emailFrom, to)
            {
                Subject = subject,
                Body = body
            };

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_emailFrom, _password),
                EnableSsl = true
            };

            client.Send(message);
        }
    }
}

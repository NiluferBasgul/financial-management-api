using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace financial_management_api.Services
{
    public class EmailSender
    {
        private readonly string _emailFrom;
        private readonly string _password;
        private readonly ILogger<EmailSender> _logger;
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings, ILogger<EmailSender> logger)
        {
            _emailSettings = emailSettings.Value;
            _emailFrom = _emailSettings.EmailFrom;
            _password = _emailSettings.Password;
            _logger = logger;
        }

        public void SendEmail(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage(_emailFrom, to)
                {
                    Subject = subject,
                    Body = body
                };

                var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
                {
                    Credentials = new NetworkCredential(_emailFrom, _password),
                    EnableSsl = _emailSettings.EnableSsl
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send email: {ex.Message}");
            }
        }
    }
}

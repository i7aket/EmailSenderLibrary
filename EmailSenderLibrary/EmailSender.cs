using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using EmailSenderLibrary.Model;


namespace EmailSenderLibrary
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailSender(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpFromName, _emailConfiguration.SmtpUsername));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    await client.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SendEmailAsync(EmailDto email)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpFromName, _emailConfiguration.SmtpUsername));
            message.To.Add(MailboxAddress.Parse(email.To));
            message.Subject = email.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = email.Body };

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    await client.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

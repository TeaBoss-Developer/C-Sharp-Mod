using System.IO;
using System.Net;
using System.Net.Mail;
namespace Mail
{
    public class Mail
    {
        public SmtpClient smtpClient { get; set; }
        public NetworkCredential credentials { get; set; }
        public void Inte(string use, string pas)
        {
            credentials = new NetworkCredential(use, pas);
        }
        public void SendMessage(string? address, string? body, string? subject, bool IsHtmlBody)
        {
            smtpClient = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true
            };

            smtpClient.Credentials = credentials;
            MailMessage message = new MailMessage
            {
                From = new MailAddress(credentials.UserName),
                Sender = new MailAddress(address),
                Subject = subject,
                IsBodyHtml = IsHtmlBody
            };
            message.To.Add(address);

            message.Body = body;

            smtpClient.Send(message);
        }
    }
}
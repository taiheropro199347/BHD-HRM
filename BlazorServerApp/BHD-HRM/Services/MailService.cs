using BHD_HRM.Data.Mail;
using System.Net;
using System.Net.Mail;

namespace BHD_HRM.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailConfig;
        public MailService(MailSettings mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public async Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody ,string AttachmentFilename)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailConfig.FromEmail);
            message.To.Add(new MailAddress(ToEmail));
            message.Subject = Subject;
            message.IsBodyHtml = true;
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(AttachmentFilename);
            message.Attachments.Add(attachment);

            message.Body = HTMLBody;
            smtp.Port = _mailConfig.Port;
            smtp.Host = _mailConfig.Host;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailConfig.Username, _mailConfig.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
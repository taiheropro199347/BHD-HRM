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

        public async Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody ,string AttachmentFilename, string attachmentImagename)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailConfig.FromEmail);
            message.To.Add(new MailAddress(ToEmail));
            message.Subject = Subject;
            message.IsBodyHtml = true;

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(HTMLBody, null, "text/html");

            System.Net.Mail.Attachment attachment;
            if (!string.IsNullOrEmpty(AttachmentFilename))
            {
                attachment = new System.Net.Mail.Attachment(AttachmentFilename);
                message.Attachments.Add(attachment);
            }
            if (!string.IsNullOrEmpty(attachmentImagename))
            {
                LinkedResource theEmailImage = new LinkedResource(attachmentImagename);
                theEmailImage.ContentId = "MyImage";
                //Add the Image to the Alternate view
                htmlView.LinkedResources.Add(theEmailImage);
                //Add view to the Email Message
                message.AlternateViews.Add(htmlView);
            }
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
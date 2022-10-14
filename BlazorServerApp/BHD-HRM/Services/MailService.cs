using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using BHD_HRM.Data.Mail;
using Microsoft.Extensions.Options;
using System.Net;

namespace BHD_HRM.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //    email.Subject = mailRequest.Subject;
        //    var builder = new BodyBuilder();
        //    if (mailRequest.Attachments != null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in mailRequest.Attachments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    file.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                }
        //                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //            }
        //        }
        //    }
        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new MailKit.Net.Smtp.SmtpClient();
        //    smtp.AuthenticationMechanisms.Remove("NTLM");
        //    smtp.AuthenticationMechanisms.Remove("XOAUTH2");
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}

        // Gửi email, theo nội dung trong mailContent
        public async Task SendEmailAsync(MailRequest mailContent)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailContent.ToEmail));
            email.Subject = mailContent.Subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.None);
                smtp.CheckCertificateRevocation = false;
                smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                var creds = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password, _mailSettings.Host);
                smtp.Authenticate(creds);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
            }

            smtp.Disconnect(true);
        }
    }
}

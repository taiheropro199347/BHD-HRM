using BHD_HRM.Data.Mail;

namespace BHD_HRM.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody, string attachmentFilename , string attachmentImagename,  string signmail);

    }
}

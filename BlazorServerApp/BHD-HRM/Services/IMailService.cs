using BHD_HRM.Data.Mail;

namespace BHD_HRM.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}

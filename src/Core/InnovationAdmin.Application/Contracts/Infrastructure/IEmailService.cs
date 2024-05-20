using InnovationAdmin.Application.Models.Mail;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}

using System.Threading.Tasks;

namespace Common.SendGrid
{
    public interface IEmailService
    {
        public Task SendEmailAsync();
    }
}
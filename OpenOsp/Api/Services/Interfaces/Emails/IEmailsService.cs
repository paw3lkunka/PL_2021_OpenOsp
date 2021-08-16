using System.Threading.Tasks;

namespace OpenOsp.Api.Services {

  public interface IEmailsService {

    Task SendEmail(string receiverAddress, string subject, string message);

    Task SendVerificationEmail(string email, string callbackUrl);

  }

}
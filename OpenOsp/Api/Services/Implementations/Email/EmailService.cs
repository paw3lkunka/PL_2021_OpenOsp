using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;
using OpenOsp.Api.Settings;

namespace OpenOsp.Api.Services {

  public class EmailsService : IEmailsService {

    public EmailsService(IOptions<EmailSettings> emailSettings) {
      _emailSettings = emailSettings.Value;
    }

    private readonly EmailSettings _emailSettings;

    public async Task SendVerificationEmail(string email, string link) {
      var body = $@"
        <h4>Welcome to OpenOSP!</h4>
        <p>We are happy to have you here so we can fight some fire together :D <p>
        <p>Please click <a href=""{link}"">this link</a> to confirm your email :)</p>
        ";
      await SendEmail(email, "OpenOSP Email Verification", body);
    }

    public async Task SendEmail(string email, string subject, string body) {
      using (var client = new SmtpClient(_emailSettings.Server)) {
        client.Port = _emailSettings.Port;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential(_emailSettings.Address, _emailSettings.Password);
        await client.SendMailAsync(new MailMessage(_emailSettings.Address, email) {
          From = new MailAddress(_emailSettings.Address, _emailSettings.Name),
          Subject = subject,
          Body = body,
          IsBodyHtml = true,
          BodyEncoding = System.Text.Encoding.UTF8
        });
      }
    }

  }

}
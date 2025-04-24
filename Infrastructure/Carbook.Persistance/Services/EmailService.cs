using Carbook.Application.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace Carbook.Persistance.Services;

public class EmailService  : IEmailService
{
    public async Task SendApprovedEmailAsync(string emailAdress, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("ahmetguvendik011348@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailAdress));
        email.Subject = "CARBOOK REZERVASYON";
        email.Body = new TextPart(TextFormat.Plain) { Text = body };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("ahmetguvendik011348@gmail.com", "kelx fmlt mtca fstp");
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public Task SendDenyEmailAsync(string emailAdress, string body)
    {
        throw new NotImplementedException();
    }
}

 

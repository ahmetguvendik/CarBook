namespace Carbook.Application.Services;

public interface IEmailService
{
    public Task SendApprovedEmailAsync(string emailAdress, string body);
    public Task SendDenyEmailAsync(string emailAdress, string body);
}
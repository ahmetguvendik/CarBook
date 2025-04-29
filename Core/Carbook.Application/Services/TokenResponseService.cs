namespace Carbook.Application.Services;

public class TokenResponseService
{
    public TokenResponseService(string token, DateTime expireDate)
    {
        Token = token;
        ExpireDate = expireDate;
    }

    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }    
}
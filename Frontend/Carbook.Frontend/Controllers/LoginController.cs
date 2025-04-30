using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Carbook.Application.Services;
using Carbook.Dto.AppUserDTOs;
using Carbook.Frontend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public LoginController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginUserDto loginUserDto)
    {
  
            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(loginUserDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5128/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenResponse != null )
                {
                    JwtSecurityTokenHandler  handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenResponse.Token);
                    var claims = token.Claims.ToList();

                    if (tokenResponse.Token != null)
                    {
                        claims.Add(new Claim("accesstoken", tokenResponse.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenResponse.ExpireDate,
                            IsPersistent = true
                        };
                        
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProps);
                        
                        return RedirectToAction("Index", "AdminCar");
                    }

                    
                  
                }
            }

            return View();
            
    }
}
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Extensions;
using SemOrder.WEB.UI.APIs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.Infrasructure.Helpers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAccountApi _accountApi;
        public AuthTokenHandler(IHttpContextAccessor httpContext,IAccountApi accountApi)
        {
            _httpContext = httpContext;
            _accountApi = accountApi;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContext.HttpContext.Request.Cookies.ContainsKey("SemOrderAccessToken"))
            {
                var cookieData = _httpContext.HttpContext.Request.Cookies["SemOrderAccessToken"].Decrypt();
                var user = System.Text.Json.JsonSerializer.Deserialize<UserResponse>(cookieData);
                if (user.AccessToken.Expires <= DateTime.Now.ToUnixTime())
                {
                    var getAccessTokenResult = await _accountApi.RefreshToken(new Common.Models.RefreshToken
                    {
                        Email = user.Email,
                        Refresh_Token = user.AccessToken.RefreshToken
                    });
                    //kontrol et
                    if (getAccessTokenResult.IsSuccess)
                    {
                        var getAccessToken = getAccessTokenResult.ResultData;
                        user.AccessToken = getAccessToken.AccessToken;

                        var claims = new List<Claim>()
                        {
                            new Claim("ID",user.ID.ToString()),
                            new Claim(ClaimTypes.Name,user.FirstName),
                            new Claim(ClaimTypes.Surname,user.LastName),
                            new Claim(ClaimTypes.Email,user.Email),
                            new Claim("Image",user.ImageUrl)
                        };

                        //Giriş işlemlerini tamamlıyoruz ve kullanıcıyı yönetici sayfasına yönlendiriyoruz....
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        _httpContext.HttpContext.Response.Cookies.Append("SemOrderAccessToken", System.Text.Json.JsonSerializer.Serialize<UserResponse>(user).Encrypt());
                        //using Microsoft.AspNetCore.Authentication;
                        await _httpContext.HttpContext.SignInAsync(principal);

                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", user.AccessToken.AccessToken);
                    }
                }
                else
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", user.AccessToken.AccessToken);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

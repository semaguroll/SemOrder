using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SemOrder.Common.DTOs.Login;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Extensions;
using SemOrder.WEB.UI.APIs;
using SemOrder.WEB.UI.Models.AccountViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;

        public AccountController(IAccountApi accountApi, IMapper mapper)
        {
            _accountApi = accountApi;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = await _accountApi.Login(_mapper.Map<LoginRequest>(request));
                if (loginRequest.IsSuccess)
                {
                    UserResponse user = loginRequest.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("ID",user.ID.ToString()),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Surname,user.LastName),
                        new Claim("Image",user.ImageUrl),
                        new Claim(ClaimTypes.MobilePhone,user.Phone),
                        new Claim(ClaimTypes.Email,user.Email)
                    };

                    //Giriş işlemlerini tamamlıyoruz ve kullanıcıyı yönetici sayfasına yönlendiriyoruz....
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    HttpContext.Response.Cookies.Append("SemOrderAccessToken", System.Text.Json.JsonSerializer.Serialize<UserResponse>(user).Encrypt());
                    //using Microsoft.AspNetCore.Authentication;
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }
            return View(request);
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("SemOrderAccessToken");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}

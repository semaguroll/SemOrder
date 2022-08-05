using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SemOrder.WEB.UI.APIs;

namespace SemOrder.WEB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public UserController(
            IWebHostEnvironment env,
            IUserApi userApi,
            IMapper mapper)
        {
            _env = env;
            _userApi = userApi;
            _mapper = mapper;
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}

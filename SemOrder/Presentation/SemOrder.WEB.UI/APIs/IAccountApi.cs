using Refit;
using SemOrder.Common.DTOs.Login;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Models;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IAccountApi
    {
        [Get("/account/login")]
        Task<WebApiResponse<UserResponse>> Login(LoginRequest request);

        [Get("/account/refreshtoken")]
        Task<WebApiResponse<UserResponse>> RefreshToken(RefreshToken request);
    }
}

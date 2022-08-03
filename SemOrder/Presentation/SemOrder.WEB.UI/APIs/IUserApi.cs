using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IUserApi
    {
        [Get("/user")]
        Task<ActionResult<WebApiResponse<List<UserResponse>>>> List();

        [Get("/user/{id}")]
        Task<ActionResult<WebApiResponse<UserResponse>>> Get(Guid id);

        [Post("/user")]
        Task<ActionResult<WebApiResponse<UserResponse>>> Add(UserRequest request);

        [Put("/user/{id}")]
        Task<ActionResult<WebApiResponse<UserResponse>>> Update(Guid id,UserRequest request);

        [Delete("/user/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/user(getactive")]
        Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetActive();

        [Get("/user/activate")]
        Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/user/inactivate")]
        Task<ActionResult<WebApiResponse<bool>>> Inactivate(Guid id);
    }
}

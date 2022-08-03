using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.Order;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{   [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderApi
    {
        [Get("/order")]
        Task<ActionResult<WebApiResponse<List<OrderResponse>>>> List();

        [Get("/order/{id}")]
        Task<ActionResult<WebApiResponse<OrderResponse>>> Get(Guid id);

        [Post("/order")]
        Task<ActionResult<WebApiResponse<OrderResponse>>> Add(OrderRequest request);

        [Put("/order/{id}")]
        Task<ActionResult<WebApiResponse<OrderResponse>>> Update(Guid id,OrderRequest request);

        [Delete("/order/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/order/getactive")]
        Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetActive();

        [Get("/order/activate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/order/inactivate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Inactivate(Guid id);
    }
}

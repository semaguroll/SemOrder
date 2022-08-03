using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.Food;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IFoodApi
    {
        [Get("/food")]
        Task<ActionResult<WebApiResponse<List<FoodResponse>>>> List();

        [Get("/food/{id}")]
        Task<ActionResult<WebApiResponse<FoodResponse>>> Get(Guid id);

        [Post("/food")]
        Task<ActionResult<WebApiResponse<FoodResponse>>> Add(FoodRequest request);

        [Put("/food/{id}")]
        Task<ActionResult<WebApiResponse<FoodResponse>>> Update(Guid id, FoodRequest request);

        [Delete("/food/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/food/getactive")]
        Task<ActionResult<WebApiResponse<List<FoodResponse>>>> GetActive();

        [Get("/food/activate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Activate();
    }
}

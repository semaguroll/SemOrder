using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.Category;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/category")]
        Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> List();

        [Get("/category/{id}")]
        Task<ActionResult<WebApiResponse<CategoryResponse>>> Get(Guid id);

        [Post("/category")]
        Task<ActionResult<WebApiResponse<CategoryResponse>>> Add(CategoryRequest request);

        [Put("/category/{id}")]
        Task<ActionResult<WebApiResponse<CategoryResponse>>> Update(Guid id,CategoryRequest request);

        [Delete("/category/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/category/getactive")]
        Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetActive();

        [Get("/category/activate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id);
    }
}

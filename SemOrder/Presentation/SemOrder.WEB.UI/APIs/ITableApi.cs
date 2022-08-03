using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ITableApi
    {
        [Get("/table")]
        Task<ActionResult<WebApiResponse<List<TableRequest>>>> List();

        [Get("/table/{id}")]
        Task<ActionResult<WebApiResponse<TableRequest>>> Get(Guid id);

        [Post("/table")]
        Task<ActionResult<WebApiResponse<TableRequest>>> Add(TableRequest tableRequest);

        [Put("/table/{id}")]
        Task<ActionResult<WebApiResponse<TableRequest>>> Update(Guid id,TableRequest tableRequest);

        [Delete("/table/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/table/getactive")]
        Task<ActionResult<WebApiResponse<List<TableRequest>>>> GetActive();

        [Get("/table/activate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/table/inactivate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Inactive(Guid id);
    }
}

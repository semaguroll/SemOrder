using Microsoft.AspNetCore.Mvc;
using Refit;
using SemOrder.Common.DTOs.Reservation;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.WEB.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IReservationApi
    {
        [Get("/reservation")]
        Task<ActionResult<WebApiResponse<List<ReservationResponse>>>> List();

        [Get("/reservation/{id}")]
        Task<ActionResult<WebApiResponse<ReservationResponse>>> Get(Guid id);

        [Post("/reservation")]
        Task<ActionResult<WebApiResponse<ReservationResponse>>> Add(ReservationRequest request);

        [Put("/reservation/{id}")]
        Task<ActionResult<WebApiResponse<ReservationResponse>>> Update(Guid id,ReservationRequest request);

        [Delete("/reservation/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Delete(Guid id);

        [Get("/reservation/getactive")]
        Task<ActionResult<WebApiResponse<List<ReservationResponse>>>> GetActive();

        [Get("/reservation/activate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/reservation/inactivate/{id}")]
        Task<ActionResult<WebApiResponse<bool>>> Inactivate(Guid id);
    }
}

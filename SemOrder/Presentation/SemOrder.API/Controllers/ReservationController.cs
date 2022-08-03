using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Reservation;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("reservation")]
    public class ReservationController : BaseApiController<ReservationController>
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepo, IMapper mapper)
        {
            _reservationRepo = reservationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<ReservationResponse>>>> GetReservations()
        {
            var reservations = await _reservationRepo.TableNoTracking.ToListAsync();
            var reservationResponse = _mapper.Map<List<ReservationResponse>>(reservations);
            if (reservations.Count > 0)
                return new WebApiResponse<List<ReservationResponse>>(true, "Success", reservationResponse);
            return new WebApiResponse<List<ReservationResponse>>(false, "Error");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ReservationResponse>>> GetReservation(Guid id)
        {
            var reservation = await _reservationRepo.GetById(id);
            if (reservation != null)
            {
                var reservationResponse = _mapper.Map<ReservationResponse>(reservation);
                return new WebApiResponse<ReservationResponse>(true, "Succcess", reservationResponse);
            }
            else
                return new WebApiResponse<ReservationResponse>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ReservationResponse>>> AddReservation(ReservationRequest request)
        {
            var addReservation = await _reservationRepo.Add(_mapper.Map<Reservation>(request));
            var reservationResponse = _mapper.Map<ReservationResponse>(addReservation);
            if(reservationResponse != null)
                return new WebApiResponse<ReservationResponse>(true, "Success", reservationResponse);
            return new WebApiResponse<ReservationResponse>(false, "Error");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ReservationResponse>>> UpdateReservation(Guid id,ReservationRequest request)
        {
            if (id != request.ID)
                return BadRequest();
            try
            {
                var reservation = await _reservationRepo.GetById(id);
                _mapper.Map(request, reservation);

                var updatedReservation = await _reservationRepo.Update(reservation);
                if (updatedReservation != null)
                {
                    var reservationResponse = _mapper.Map<ReservationResponse>(updatedReservation);
                    return new WebApiResponse<ReservationResponse>(true, "Success", reservationResponse);
                }
                else
                    return new WebApiResponse<ReservationResponse>(false, "Error");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> DeleteReservation(Guid id)
        {
            var reservation = await _reservationRepo.GetById(id);
            if (reservation == null)
                return NotFound();
            var deletedReservation = await _reservationRepo.Remove(reservation);
            if (deletedReservation)
                return new WebApiResponse<bool>(true, "Success", deletedReservation);
            return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<ReservationResponse>>>> GetActiveReservations()
        {
            var reservations = await _reservationRepo.GetActive().ToListAsync();
            var activeReservations = _mapper.Map<List<ReservationResponse>>(reservations);
            if (activeReservations != null)
                return new WebApiResponse<List<ReservationResponse>>(true, "Success", activeReservations);
            return new WebApiResponse<List<ReservationResponse>>(false,"Error");    
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateReservations(Guid id)
        {
            var reservation = await _reservationRepo.Activate(id);
            if (reservation)
                return new WebApiResponse<bool>(true, "Success", reservation);
            return new WebApiResponse<bool>(false,"Error");
        }
        [HttpGet("inactivate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> InactivateReservations(Guid id)
        {
            var reservation = await _reservationRepo.Inactivate(id);
            if (reservation)
                return new WebApiResponse<bool>(true, "Success", reservation);
            return new WebApiResponse<bool>(false, "Error");
        }
    }
}

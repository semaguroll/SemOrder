using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Order;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("order")]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetOrders()
        {
            var orders = await _orderRepo.TableNoTracking.ToListAsync();
            var orderResponse = _mapper.Map<List<OrderResponse>>(orders);
            if (orderResponse.Count > 0)
                return new WebApiResponse<List<OrderResponse>>(true, "Success", orderResponse);
            return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> GetOrder(Guid id)
        {
            var order = await _orderRepo.GetById(id);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            if (orderResponse != null)
                return new WebApiResponse<OrderResponse>(true, "Success", orderResponse);
            return new WebApiResponse<OrderResponse>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> AddOrder(OrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            var addOrder = await _orderRepo.Add(order);
            var orderResponse = _mapper.Map<OrderResponse>(addOrder);
            if (orderResponse != null)
                return new WebApiResponse<OrderResponse>(true, "Success", orderResponse);
            return new WebApiResponse<OrderResponse>(false, "Error");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> UpdateOrder(Guid id, OrderRequest request)
        {
            if (id != request.ID)
                return BadRequest();

            try
            {
                var order = await _orderRepo.GetById(id);
                _mapper.Map(request, order);

                var updatedOrder = await _orderRepo.Update(order);
                if(updatedOrder != null)
                {
                    var orderResponse = _mapper.Map<OrderResponse>(updatedOrder);
                    return new WebApiResponse<OrderResponse>(true, "Success", orderResponse);
                }
                else 
                    return new WebApiResponse<OrderResponse>(false, "Error");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> DeleteOrder(Guid id)
        {
            var order = await _orderRepo.GetById(id);
            if (order == null)
                return NotFound();
            var deletedOrder = await _orderRepo.Remove(order);
            if(deletedOrder)
                return new WebApiResponse<bool>(true, "Error", true);
            return new WebApiResponse<bool>(false, "Error",false);
        }
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetActiveOrders()
        {
            var activeOrders = await _orderRepo.GetActive().ToListAsync();
            if (activeOrders.Count>0)
            {
                var orderResponse = _mapper.Map<List<OrderResponse>>(activeOrders);
                return new WebApiResponse<List<OrderResponse>>(true, "Success", orderResponse);
            }
            else
                return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateOrder(Guid id)
        {
            var order = await _orderRepo.Activate(id);
            if (order)
                return new WebApiResponse<bool>(true, "Success", order);
            return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("inactivate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> InactivateOrder(Guid id)
        {
            var order = await _orderRepo.Inactivate(id);
            if (order)
                return new WebApiResponse<bool>(true, "Success", order);
            return new WebApiResponse<bool>(false, "Error");
        }
    }
}

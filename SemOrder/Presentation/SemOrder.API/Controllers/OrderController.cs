using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Order;
using SemOrder.Common.Models;
using SemOrder.Service.Repository.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("order")]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepo,IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetOrders()
        {
            var orders = await _orderRepo.TableNoTracking.ToListAsync();
            if (orders.Count > 0)
            {
                var orderResponse = _mapper.Map<List<OrderResponse>>(orders);
                return new WebApiResponse<List<OrderResponse>>(true, "Success", orderResponse);
            }
            else
                return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Food;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.Food;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("food")]
    public class FoodController : BaseApiController<FoodController>
    {
        private readonly IFoodRepository _foodRepo;
        private readonly IMapper _mapper;
        public FoodController(IFoodRepository foodRepo, IMapper mapper)
        {
            _foodRepo = foodRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<FoodResponse>>>> GetFoods()
        {
            var foods = await _foodRepo.TableNoTracking.ToListAsync();
            var foodResponse = _mapper.Map<List<FoodResponse>>(foods);
            if (foodResponse.Count > 0)
                return new WebApiResponse<List<FoodResponse>>(true, "Success", foodResponse);
            return new WebApiResponse<List<FoodResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<FoodResponse>>> GetFood(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            var food = await _foodRepo.GetById(id);
            var foodResponse = _mapper.Map<FoodResponse>(food);
            if (foodResponse != null)
                return new WebApiResponse<FoodResponse>(true, "Success", foodResponse);
            return new WebApiResponse<FoodResponse>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<FoodResponse>>> AddFood(FoodRequest request)
        {
            var food = _mapper.Map<Food>(request);
            var addFood = await _foodRepo.Add(food);
            var foodResponse = _mapper.Map<FoodResponse>(addFood);
            if (foodResponse != null)
                return new WebApiResponse<FoodResponse>(true, "Success", foodResponse);
            return new WebApiResponse<FoodResponse>(false, "Error");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<FoodResponse>>> UpdateFood(Guid id, FoodRequest request)
        {
            if (id != request.ID)
                return BadRequest();

            try
            {
                Food food = await _foodRepo.GetById(id);
                if (food == null)
                    return NotFound();

                _mapper.Map(request, food);

                var updatedFood = await _foodRepo.Update(food);
                if (updatedFood != null)
                {
                    var foodResponse = _mapper.Map<FoodResponse>(updatedFood);
                    return new WebApiResponse<FoodResponse>(true, "Success", foodResponse);
                }
                return new WebApiResponse<FoodResponse>(false, "Error");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> DeleteFood(Guid id)
        {
            var food = await _foodRepo.GetById(id);
            var deletedFood = await _foodRepo.Remove(food);
            if (deletedFood)
                return new WebApiResponse<bool>(true, "Success", true);
            return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<FoodResponse>>>> GetActiveFoods()
        {
            var activeFoods = await _foodRepo.GetActive().ToListAsync();
            if (activeFoods.Count > 0)
            {
                var foodResponse = _mapper.Map<List<FoodResponse>>(activeFoods);
                return new WebApiResponse<List<FoodResponse>>(true, "Success", foodResponse);
            }
            else
                return new WebApiResponse<List<FoodResponse>>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateFood(Guid id)
        {
            var activeFood = await _foodRepo.Activate(id);
            if (activeFood)
                return new WebApiResponse<bool>(true, "Success", activeFood);
            return new WebApiResponse<bool>(false, "Error");
        }
    }
}

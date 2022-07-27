using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Category;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("category")]
    public class CategoryController : BaseApiController<CategoryController>
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryController( ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetCategories()
        {            
            var data = await _categoryRepo.TableNoTracking.ToListAsync();
            var categoryResult = _mapper.Map<List<CategoryResponse>>(data);
            if (categoryResult.Count > 0)
                return new WebApiResponse<List<CategoryResponse>>(true, "Success", categoryResult);
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> GetCategory(Guid id)
        {
            var categoryResult = _mapper.Map<CategoryResponse>(await _categoryRepo.GetById(id));
            if (categoryResult != null)
                return new WebApiResponse<CategoryResponse>(true, "Success", categoryResult);
            return new WebApiResponse<CategoryResponse>(false, "Error");


        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> AddCategory(CategoryRequest request)
        {
            var categoryMap = _mapper.Map<Category>(request);
            var category = await _categoryRepo.Add(categoryMap);
            if(category != null)
            {
                var categoryResponseMap = _mapper.Map<CategoryResponse>(category);
                return new WebApiResponse<CategoryResponse>(true, "Success", categoryResponseMap);
            }
            else
                return new WebApiResponse<CategoryResponse>(false, "Error");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> UpdateCategory(Guid id,CategoryRequest request)
        {
            if (id != request.ID)
                return BadRequest();
            try
            {
                Category categoryMap =await _categoryRepo.GetById(id);
                if(categoryMap == null)
                    return NotFound();

                _mapper.Map(request, categoryMap);

                var updateCategory = await _categoryRepo.Update(categoryMap);
                if(updateCategory != null)
                {
                    var categoryResponse = _mapper.Map<CategoryResponse>(updateCategory);
                    return new WebApiResponse<CategoryResponse>(true ,"Success", categoryResponse);
                }
                else
                    return new WebApiResponse<CategoryResponse>(false, "Error");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> DeleteCategory(Guid id)
        {
            Category categoryResult = await _categoryRepo.GetById(id);
            if (categoryResult == null)
                return NotFound();
            var deleteCategory = await _categoryRepo.Remove(categoryResult);
            if (deleteCategory)
            {
                var categoryResponse = _mapper.Map<CategoryResponse>(categoryResult);
                return new WebApiResponse<CategoryResponse>(true, "Success", categoryResponse);
            }
            else
                return new WebApiResponse<CategoryResponse>(false, "Error");
        }
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetActiveCategories()
        {
            var activeCategories = await _categoryRepo.GetActive().ToListAsync();
            var categoryResponse = _mapper.Map<List<CategoryResponse>>(activeCategories);
            if (categoryResponse.Count > 0)
                return new WebApiResponse<List<CategoryResponse>>(true, "Success", categoryResponse);
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateCategory(Guid id)
        {
            bool activated = await _categoryRepo.Activate(id);
            if (activated)
                return new WebApiResponse<bool>(true, "Success", true);
            return new WebApiResponse<bool>(false, "Error");
        }


    }
}

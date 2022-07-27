using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Category;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Models;
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
            {
                return new WebApiResponse<List<CategoryResponse>>(true, "Success", categoryResult);
            }
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> GetCategory(Guid id)
        {
            var categoryResult = _mapper.Map<CategoryResponse>(await _categoryRepo.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<CategoryResponse>(true, "Success", categoryResult);
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

    }
}

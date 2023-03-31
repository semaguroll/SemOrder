using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Food;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Category
{
    public class CategoryResponse : BaseDto
    {
        public CategoryResponse()
        {
            Foods = new HashSet<FoodResponse>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<FoodResponse> Foods { get; set; }
    }
}

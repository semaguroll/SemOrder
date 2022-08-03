using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Category;
using SemOrder.Common.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Food
{
    public class FoodResponse : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryRequest Category { get; set; }
    }
}

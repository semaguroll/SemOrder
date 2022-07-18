using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Food
{
    public class FoodRequest : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }

        public Guid CategoryId { get; set; }
        public Guid OrderId { get; set; }
    }
}

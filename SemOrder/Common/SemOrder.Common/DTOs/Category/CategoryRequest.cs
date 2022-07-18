using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Category
{
    public class CategoryRequest : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

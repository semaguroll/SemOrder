using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Category : CoreEntity
    {
        public Category()
        {
            Foods = new HashSet<Food>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}

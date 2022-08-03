using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Food : CoreEntity
    {
        public Food()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    
    }
}

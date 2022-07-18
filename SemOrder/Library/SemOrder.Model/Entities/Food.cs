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
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

    }
}

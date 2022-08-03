using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Order : CoreEntity
    {
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TableId { get; set; }
        public Table Table { get; set; }

        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}

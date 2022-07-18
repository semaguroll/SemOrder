using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            Foods = new HashSet<Food>();
        }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TableId { get; set; }
        public Table Table { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}

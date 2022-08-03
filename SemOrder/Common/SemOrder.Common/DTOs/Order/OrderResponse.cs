using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Food;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.DTOs.User;
using System;

namespace SemOrder.Common.DTOs.Order
{
    public class OrderResponse : BaseDto
    {
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }


        public Guid UserId { get; set; }
        public UserRequest User { get; set; }

        public Guid TableId { get; set; }
        public TableRequest Table { get; set; }

        public Guid FoodId { get; set; }
        public FoodRequest Food { get; set; }
    }
}

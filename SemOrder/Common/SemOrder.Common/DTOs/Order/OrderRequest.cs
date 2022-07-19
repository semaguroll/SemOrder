using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Order
{
    public class OrderRequest : BaseDto
    {
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }

        public Guid TableId { get; set; }
    }
}

using SemOrder.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public Status Status { get; set; }
        [Display(Name = "Miktar")]
        [Required]
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        [Required]
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
        public Guid FoodId { get; set; }
    }
}

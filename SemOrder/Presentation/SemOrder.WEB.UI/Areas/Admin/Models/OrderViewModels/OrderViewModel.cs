using SemOrder.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.OrderViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TableId { get; set; }
        public Table Table { get; set; }

        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}

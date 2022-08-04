using SemOrder.Common.Enums;
using SemOrder.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.FoodViewModels
{
    public class FoodViewModel
    {
        public FoodViewModel()
        {
            Orders = new HashSet<Order>();
        }
        [Display(Name = "Yemek veya İçecek Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Fiyat")]
        public float Price { get; set; }

        public FoodTypes Type { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

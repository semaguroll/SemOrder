using SemOrder.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.FoodViewModels
{
    public class UpdateFoodViewModel
    {
        public Guid ID { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Yemek veya İçecek Adı girilmesi zorunludur.")]
        [Display(Name = "Yemek veya İçecek Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Fiyat")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Tür seçimi zorunludur.")]
        public FoodTypes Type { get; set; }

        public Guid CategoryId { get; set; }
    }
}

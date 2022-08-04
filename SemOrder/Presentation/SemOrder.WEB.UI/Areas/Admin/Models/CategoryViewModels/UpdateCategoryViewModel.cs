using SemOrder.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.CategoryViewModels
{
    public class UpdateCategoryViewModel
    {
        public Guid ID { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Kategori adı girilmesi zorunludur.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

using SemOrder.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Foods = new HashSet<Food>();
        }

        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}

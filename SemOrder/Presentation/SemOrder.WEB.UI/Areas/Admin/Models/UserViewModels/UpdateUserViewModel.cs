using SemOrder.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.UserViewModels
{
    public class UpdateUserViewModel
    {
        public Guid ID { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "İsim giriniz.")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim giriniz.")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola giriniz.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}

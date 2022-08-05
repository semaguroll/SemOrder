using SemOrder.WEB.UI.Areas.Admin.Models.UserViewModels;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password giriniz.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}

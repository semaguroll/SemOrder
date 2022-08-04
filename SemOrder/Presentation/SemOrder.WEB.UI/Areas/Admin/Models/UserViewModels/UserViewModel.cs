using SemOrder.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.UserViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        public string Password { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}

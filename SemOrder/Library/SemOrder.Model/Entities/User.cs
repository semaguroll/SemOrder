using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class User : CoreEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}

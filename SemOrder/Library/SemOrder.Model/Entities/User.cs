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
            Bookings = new HashSet<Booking>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}

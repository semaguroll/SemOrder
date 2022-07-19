using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Table : CoreEntity
    {
        public Table()
        {
            Reservations = new HashSet<Reservation>();
            Orders = new HashSet<Order>();
        }
        public string TableNum { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}

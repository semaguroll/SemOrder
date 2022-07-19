using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class Booking : CoreEntity
    {
        public string BookingDescription { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TableId { get; set; }
        public Table Table { get; set; }
    }
}

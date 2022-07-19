using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Booking
{
    public class BookingRequest : BaseDto
    {
        public string BookingDescription { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }

        public Guid CustomerId { get; set; }
        public Guid TableId { get; set; }
    }
}

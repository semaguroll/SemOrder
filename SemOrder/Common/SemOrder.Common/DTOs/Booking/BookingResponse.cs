using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Booking
{
    public class BookingResponse : BaseDto
    {
        public string BookingDescription { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }

        public UserRequest User { get; set; }
        public Guid UserId { get; set; }
        public TableRequest Table { get; set; }
        public Guid TableId { get; set; }
    }
}

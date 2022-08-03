using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Reservation
{
    public class ReservationRequest : BaseDto
    {
        public string Message { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int NumberOfPerson { get; set; }

        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
    }
}

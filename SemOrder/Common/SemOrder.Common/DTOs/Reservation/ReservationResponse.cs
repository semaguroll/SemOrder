using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Reservation
{
    public class ReservationResponse : BaseDto
    {
        public string Message { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int NumberOfPerson { get; set; }

        public UserRequest User { get; set; }
        public Guid UserId { get; set; }
        public TableRequest Table { get; set; }
        public Guid TableId { get; set; }
    }
}

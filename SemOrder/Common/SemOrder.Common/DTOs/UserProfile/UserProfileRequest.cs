using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.UserProfile
{
    public class UserProfileRequest : BaseDto
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
    }
}

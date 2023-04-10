using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.UserProfile
{
    public class UserProfileResponse : BaseDto
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

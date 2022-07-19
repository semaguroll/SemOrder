using SemOrder.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.User
{
    public class UserRequest : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

using SemOrder.Common.DTOs.Base;
using SemOrder.Common.DTOs.Food;
using SemOrder.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.User
{
    public class UserResponse : BaseDto
    {
        public UserResponse()
        {
            Foods = new HashSet<FoodResponse>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }

        public GetAccessToken AccessToken { get; set; }

        public ICollection<FoodResponse> Foods { get; set; }
    }
}

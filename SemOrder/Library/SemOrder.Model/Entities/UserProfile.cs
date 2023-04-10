using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Entities
{
    public class UserProfile : CoreEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public User CreatedUserProfile { get; set; }
        public User ModifiedUserProfile { get; set; }
    }
}

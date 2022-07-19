using SemOrder.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.WorkContext
{
    public interface IWorkContext
    {
        UserResponse CurrentUser { get; set; }
    }
}

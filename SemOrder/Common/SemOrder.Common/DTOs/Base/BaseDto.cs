using SemOrder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.DTOs.Base
{
    public class BaseDto
    { 
        public Guid ID { get; set; }
        public Status Status { get; set; }
    }
}

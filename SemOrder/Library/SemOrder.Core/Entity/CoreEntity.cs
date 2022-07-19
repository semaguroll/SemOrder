using SemOrder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Core.Entity
{
    public class CoreEntity
    {
        public Guid ID { get; set; }
        public Status Status { get; set; }
    }
}

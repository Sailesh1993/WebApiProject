using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Entities
{
    public class BaseEntity: TimeStamp
    {
        public Guid Id{ get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Entities
{
    public class TimeStamp
    {
         public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Entities
{
    public class Order
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public List<OrderProduct>OrderProducts{ get; set; }//navigation property 
    }
}
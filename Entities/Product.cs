using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float Price{ get; set; }
        public int Inventory{ get; set; }
    }
}
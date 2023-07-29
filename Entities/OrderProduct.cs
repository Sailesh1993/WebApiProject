using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Entities
{/* 
    Product 1-n OrderProduct n-1 - Order */
    [PrimaryKey(nameof(ProductId), nameof(OrderId))]
    public class OrderProduct
    {
        [ForeignKey(nameof(Product))] // data annotation
        public Guid ProductId{ get; set; } // foreign key property
        public Product Product{ get; set; } //navigation property -> in database: productId, fk to product rable
       
        [ForeignKey(nameof(Order))]
        public Guid OrderId{ get; set; }
        public Order Order{ get; set; } // oderId fk Order
        public int Amount{ get; set; }
    }

    /* public class OrderProduct{
        public Guid Id{ get; set; }
        public Product Product { get; set; } // navigation property -> in database: productId, fk to product table
        public Order Order { get; set; } // orderId fk Order
        public int Amount{ get; set; }
    } */
}
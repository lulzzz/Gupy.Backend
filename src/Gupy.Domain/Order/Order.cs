using System;
using System.Collections.Generic;
using System.Linq;

namespace Gupy.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime? DateShipped { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public float TotalSum => OrderItems.Sum(oi => oi.Quantity * oi.PricePerUnit);

        public int ShippingDetailsId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
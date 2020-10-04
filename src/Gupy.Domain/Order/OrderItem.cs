﻿ namespace Gupy.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
    }
}
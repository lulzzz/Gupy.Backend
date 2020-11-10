using System;
using Gupy.Domain;

namespace Gupy.Api.Models.Order
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public DateTime? DateShipped { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
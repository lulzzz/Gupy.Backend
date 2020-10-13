using Gupy.Domain;

namespace Gupy.Api.Models.Order
{
    public class UpdateOrderStatusModel
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
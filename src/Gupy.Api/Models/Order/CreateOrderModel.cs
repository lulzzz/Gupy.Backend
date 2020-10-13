using System.Collections.Generic;

namespace Gupy.Api.Models.Order
{
    public class CreateOrderModel
    {
        public int ShippingDetailsId { get; set; }
        public ICollection<CreateOrderItemModel> OrderItems { get; set; } = new List<CreateOrderItemModel>();
    }
}
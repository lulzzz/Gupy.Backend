namespace Gupy.Core.Dtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
    }
}
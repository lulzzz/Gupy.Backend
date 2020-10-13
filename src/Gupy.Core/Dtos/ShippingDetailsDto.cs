namespace Gupy.Core.Dtos
{
    public class ShippingDetailsDto
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TelegramUserId { get; set; }
    }
}
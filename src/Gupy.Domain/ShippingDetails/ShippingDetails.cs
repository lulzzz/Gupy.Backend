 using System.Collections.Generic;

 namespace Gupy.Domain
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int TelegramUserId { get; set; }
        public TelegramUser TelegramUser { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
namespace Gupy.Api.Models.ShippingDetails
{
    public class CreateDetailsModel
    {
        public string ReceiverName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TelegramUserId { get; set; }
    }
}
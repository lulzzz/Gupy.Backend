using System;
using System.Collections.Generic;

namespace Gupy.Domain
{
    public class TelegramUser
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateJoined { get; set; }
        
        public ICollection<ShippingDetails> ShippingDetails { get; set; } = new List<ShippingDetails>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
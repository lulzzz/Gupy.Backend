using System;

namespace Gupy.Core.Dtos
{
    public class TelegramUserDto
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
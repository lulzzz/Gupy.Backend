namespace Gupy.Api.Models.TelegramUser
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
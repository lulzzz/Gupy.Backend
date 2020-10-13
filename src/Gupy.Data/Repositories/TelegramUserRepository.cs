using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class TelegramUserRepository : Repository<TelegramUser>, ITelegramUserRepository
    {
        public TelegramUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
using API.Interfaces.Repositories;
using API.Models;

namespace API.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ChallengeCGDbContext context) : base(context)
        {
        }
    }
}

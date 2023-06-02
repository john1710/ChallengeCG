using API.Data.Account;
using API.Models;

namespace API.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Account> GetById(long id);
        Task<ICollection<Account>> GetAll();
        Task<Account> Update(UpsertAccountInput entity);
        Task<Account> Create(UpsertAccountInput entity);
        Task Delete(long id);
    }
}

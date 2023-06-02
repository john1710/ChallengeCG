using Web.Data.Input;
using Web.Models;

namespace Web.Interfaces
{
    public interface IAccountService
    {
        Task<AccountViewModel> GetById(long id);
        Task<List<AccountViewModel>> GetAll();
        Task<AccountViewModel> Create(UpsertAccountInput entity);
        Task<AccountViewModel> Update(UpsertAccountInput entity);
        Task Delete(long id);
    }
}

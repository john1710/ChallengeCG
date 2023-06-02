using API.Models;

namespace API.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> GetById(long id);
        Task Delete(long id);
        Task<ICollection<T>> GetAll();
        Task<T> Update(T entity);
    }
}

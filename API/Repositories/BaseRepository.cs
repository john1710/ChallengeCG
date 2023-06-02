using API.Interfaces.Repositories;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repositories
{
    public class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly ChallengeCGDbContext _context;
        private DbSet<T> _dbSet;
        public BaseRepository(ChallengeCGDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("entity not found!");
        }
        public async Task Delete(long id)
        {
            var entity = await _dbSet.FindAsync(id) ?? throw new Exception("entity not found!");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

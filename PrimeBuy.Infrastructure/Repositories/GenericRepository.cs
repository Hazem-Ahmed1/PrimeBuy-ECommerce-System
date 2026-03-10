using Microsoft.EntityFrameworkCore;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);

        public void Delete(T entity) => dbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(object id) => await dbSet.FindAsync(id);

        public void Update(T entity) => dbSet.Update(entity);
    }
}

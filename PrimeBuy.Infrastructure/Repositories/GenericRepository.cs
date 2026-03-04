using Microsoft.EntityFrameworkCore;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> dbSet;
        public GenericRepository(AppDbContext db_context) 
        {
            _context = db_context;
            dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
           await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}

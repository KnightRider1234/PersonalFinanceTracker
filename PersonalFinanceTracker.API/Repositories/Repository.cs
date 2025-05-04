using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.API.Data;
using PersonalFinanceTracker.API.Interfaces;
using PersonalFinanceTracker.API.Models;

namespace PersonalFinanceTracker.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entry)
        {
            await _dbSet.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entry)
        {
            _dbSet.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _dbSet.FindAsync(id);
            if (entry != null)
            {
                _dbSet.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using PersonalFinanceTracker.API.Models;

namespace PersonalFinanceTracker.API.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entry);
        Task UpdateAsync(T entry);
        Task DeleteAsync(int id);
    }
}
namespace PersonalFinanceTracker.Client.Interfaces
{
    public interface IHttpDataService<T> where T : class
    {
        Task<List<T>> GetAllAsync(string url);
        Task<T?> GetByIdAsync(string url, int id);
        Task PostAsync(string url, T data);
        Task PutAsync(string url, int id, T data);
        Task DeleteAsync(string url, int id);
    }
}
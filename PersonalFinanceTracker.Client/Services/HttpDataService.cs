using PersonalFinanceTracker.Client.Interfaces;
using System.Net.Http.Json;

namespace PersonalFinanceTracker.Client.Services
{
    public class HttpDataService<T> : IHttpDataService<T> where T : class
    {
        protected readonly HttpClient _http;

        public HttpDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<T>> GetAllAsync(string url)
        {
            var result = await _http.GetFromJsonAsync<List<T>>(url);
            return result ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync(string url, int id)
        {
            return await _http.GetFromJsonAsync<T>($"{url}/{id}");
        }

        public async Task PostAsync(string url, T data)
        {
            var response = await _http.PostAsJsonAsync(url, data);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"POST failed. Status: {response.StatusCode}");
        }

        public async Task PutAsync(string url, int id, T data)
        {
            var response = await _http.PutAsJsonAsync($"{url}/{id}", data);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"PUT failed. Response: {error}");
            }
        }

        public async Task DeleteAsync(string url, int id)
        {
            var response = await _http.DeleteAsync($"{url}/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"DELETE failed. Status: {response.StatusCode}");
        }
    }
}

using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7054/api/Inventory/");
        }

        public async Task<List<Inventory>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Inventory>>("/api/Inventory");
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Inventory>($"/api/Inventory/{id}");
        }

        public async Task AddProductAsync(Inventory inventory)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Inventory", inventory);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(int id, Inventory inventory)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Inventory{id}", inventory);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Inventory/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

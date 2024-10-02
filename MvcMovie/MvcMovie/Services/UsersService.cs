using MvcMovie.Models;

namespace MvcMovie.Services
{
    public class UsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>?> GetUsers()
        {
            var response = await _httpClient.GetAsync("http://localhost:5286/api/Users");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<List<User>>();

            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5286/api/Users/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task AddUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5286/api/Users", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUser(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5286/api/Users/{user.Id}", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5286/api/Users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
using MvcMovie.Models;

namespace MvcMovie.Services
{
    public class GenresService
    {
        private readonly HttpClient _httpClient;

        public GenresService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Genre>?> GetGenres()
        {
            var response = await _httpClient.GetAsync("http://localhost:5286/api/Genres");
            response.EnsureSuccessStatusCode();
            var genres = await response.Content.ReadFromJsonAsync<List<Genre>>();

            return genres;
        }

        public async Task<Genre?> GetGenreById(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5286/api/Genres/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Genre>();
        }

        public async Task AddGenre(Genre genre)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5286/api/Genres", genre);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGenre(Genre genre)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5286/api/Genres/{genre.Id}", genre);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGenre(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5286/api/Genres/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
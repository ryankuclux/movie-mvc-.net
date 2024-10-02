using MvcMovie.Models;

namespace MvcMovie.Services
{
    public class MoviesService
    {
        private readonly HttpClient _httpClient;

        public MoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>?> GetMovies()
        {
            var response = await _httpClient.GetAsync("http://localhost:5286/api/Movies");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();

            return movies;
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5286/api/Movies/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Movie>();
        }

        public async Task AddMovie(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5286/api/Movies", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateMovie(Movie movie)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5286/api/Movies/{movie.Id}", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMovie(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5286/api/Movies/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Genre>?> GetGenres()
        {
            var response = await _httpClient.GetAsync("http://localhost:5286/api/Genres");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Genre>>();
        }
    }
}
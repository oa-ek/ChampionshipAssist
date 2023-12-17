using ChampionshipAssistBlazorRepresentation.Application;
using System.Net.Http.Json;
using System.Text.Json;

namespace ChampionshipAssistBlazorRepresentation.Services
{
	public class ReviewService
	{
		private readonly HttpClient _httpClient;
		private const string ApiUrl = "https://localhost:7088";

        public ReviewService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private async Task<T> HandleApiResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            try
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ReviewModel>> GetReviewsAsync()
		{
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/ReviewApi");
                return await HandleApiResponse<List<ReviewModel>>(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching reviews: {ex.Message}");
                throw;
            }
        }

		public async Task<ReviewModel> GetReviewByIdAsync(string id)
		{
			var item = await _httpClient.GetAsync(ApiUrl + $"/api/ReviewApi/{id}");
			return (await item.Content.ReadFromJsonAsync<ReviewModel>())!;
		}

		public async Task<ReviewModel> AddReviewAsync(ReviewModel review)
		{
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiUrl + "/api/ReviewApi", review);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<ReviewModel>();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error adding review: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateReviewAsync(string id, ReviewModel review)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/ReviewApi/{id}", review);

                if (response.IsSuccessStatusCode)
                {
                    var updatedReview = await response.Content.ReadFromJsonAsync<ReviewModel>();
                }
                else
                {
                    Console.WriteLine($"Error updating review. Status code: {response.StatusCode}");

                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response content: {responseContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error updating review: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteReviewAsync(string id)
		{
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/api/ReviewApi/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error deleting review: {ex.Message}");
                throw;
            }
        }
	}
}

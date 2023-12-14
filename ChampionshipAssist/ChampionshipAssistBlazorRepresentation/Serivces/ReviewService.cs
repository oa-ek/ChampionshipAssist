using ChampionshipAssist.Application;
using System.Net.Http.Json;

namespace ChampionshipAssistBlazorRepresentation.Serivces
{
	public class ReviewService
	{
		private readonly HttpClient _httpClient;
		private const string ApiUrl = "https://localhost:8001";

		public ReviewService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Review>> GetReviewsAsync()
		{
			var items = await _httpClient.GetAsync(ApiUrl + "/api/ReviewApi");
			return (await items.Content.ReadFromJsonAsync<List<Review>>())!;
		}

		public async Task<Review> GetReviewByIdAsync(Guid id)
		{
			var item = await _httpClient.GetAsync(ApiUrl + $"/api/ReviewApi/{id}");
			return (await item.Content.ReadFromJsonAsync<Review>())!;
		}

		public async Task<Review> AddReviewAsync(Review review)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiUrl + $"/api/ReviewApi", review);
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<Review>())!;
		}

		public async Task UpdateReviewAsync(Guid id, Review review)
		{
			var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/ReviewApi/{id}", review);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteReviewAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(ApiUrl + $"/api/ReviewApi/{id.ToString()}");
			response.EnsureSuccessStatusCode();
		}
	}
}

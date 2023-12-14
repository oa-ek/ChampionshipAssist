using ChampionshipAssist.Application;
using System.Net.Http.Json;

namespace ChampionshipAssistBlazorRepresentation.Serivces
{
	public class UserService
	{
		private readonly HttpClient _httpClient;
		private const string ApiUrl = "https://localhost:8001";

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<User>> GetUsersAsync()
		{
			var items = await _httpClient.GetAsync(ApiUrl + "/api/UserApi");
			return (await items.Content.ReadFromJsonAsync<List<User>>())!;
		}

		public async Task<User> GetUserByIdAsync(Guid id)
		{
			var item = await _httpClient.GetAsync(ApiUrl + $"/api/UserApi/{id}");
			return (await item.Content.ReadFromJsonAsync<User>())!;
		}

		public async Task<User> AddUserAsync(User user)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiUrl + $"/api/UserApi", user);
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<User>())!;
		}

		public async Task UpdateUserAsync(Guid id, User user)
		{
			var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/UserApi/{id}", user);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(ApiUrl + $"/api/UserApi/{id.ToString()}");
			response.EnsureSuccessStatusCode();
		}
	}
}

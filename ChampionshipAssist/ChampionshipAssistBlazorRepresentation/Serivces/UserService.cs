using ChampionshipAssistBlazorRepresentation.Application;
using System.Net.Http.Json;

namespace ChampionshipAssistBlazorRepresentation.Services
{
	public class UserService
	{
		private readonly HttpClient _httpClient;
		private const string ApiUrl = "https://localhost:7088";

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<UserModel>> GetUsersAsync()
		{
			var items = await _httpClient.GetAsync(ApiUrl + "/api/UserApi");
			return (await items.Content.ReadFromJsonAsync<List<UserModel>>())!;
		}

		public async Task<UserModel> GetUserByIdAsync(Guid id)
		{
			var item = await _httpClient.GetAsync(ApiUrl + $"/api/UserApi/{id}");
			return (await item.Content.ReadFromJsonAsync<UserModel>())!;
		}

		public async Task<UserModel> AddUserAsync(UserModel user)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiUrl + $"/api/UserApi", user);
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<UserModel>())!;
		}

		public async Task UpdateUserAsync(string id, UserModel user)
		{
			var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/UserApi/{id}", user);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteUserAsync(string id)
		{
			var response = await _httpClient.DeleteAsync(ApiUrl + $"/api/UserApi/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}

using ChampionshipAssistBlazorRepresentation.Application;
using System.Net.Http.Json;

namespace ChampionshipAssistBlazorRepresentation.Services
{
	public class TournamentService
	{
			private readonly HttpClient _httpClient;
			private const string ApiUrl = "https://localhost:7088";

			public TournamentService(HttpClient httpClient)
			{
				_httpClient = httpClient;
			}

			public async Task<List<TournamentModel>> GetTournamentsAsync()
			{
				var items = await _httpClient.GetAsync(ApiUrl + "/api/TournamentApi");
				return (await items.Content.ReadFromJsonAsync<List<TournamentModel>>())!;
			}

			public async Task<TournamentModel> GetTournamentByIdAsync(Guid id)
			{
				var item = await _httpClient.GetAsync(ApiUrl + $"/api/TournamentApi/{id}");
				return (await item.Content.ReadFromJsonAsync<TournamentModel>())!;
			}

			public async Task<TournamentModel> AddTournamentAsync(TournamentModel tournament)
			{
				var response = await _httpClient.PostAsJsonAsync(ApiUrl + $"/api/TournamentApi", tournament);
				response.EnsureSuccessStatusCode();

				return (await response.Content.ReadFromJsonAsync<TournamentModel>())!;
			}

			public async Task UpdateTournamentAsync(string id, TournamentModel tournament)
			{
				var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/TournamentApi/{id}", tournament);
				response.EnsureSuccessStatusCode();
			}

			public async Task DeleteTournamentAsync(string id)
			{
				var response = await _httpClient.DeleteAsync(ApiUrl + $"/api/TournamentApi/{id}");
				response.EnsureSuccessStatusCode();
			}
	}
}

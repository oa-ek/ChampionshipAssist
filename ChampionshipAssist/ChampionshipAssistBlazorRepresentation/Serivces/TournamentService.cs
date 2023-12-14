using ChampionshipAssist.Application;
using System.Net.Http.Json;

namespace ChampionshipAssistBlazorRepresentation.Serivces
{
	public class TournamentService
	{
			private readonly HttpClient _httpClient;
			private const string ApiUrl = "https://localhost:8001";

			public TournamentService(HttpClient httpClient)
			{
				_httpClient = httpClient;
			}

			public async Task<List<Tournament>> GetTournamentsAsync()
			{
				var items = await _httpClient.GetAsync(ApiUrl + "/api/TournamentApi");
				return (await items.Content.ReadFromJsonAsync<List<Tournament>>())!;
			}

			public async Task<Tournament> GetTournamentByIdAsync(Guid id)
			{
				var item = await _httpClient.GetAsync(ApiUrl + $"/api/TournamentApi/{id}");
				return (await item.Content.ReadFromJsonAsync<Tournament>())!;
			}

			public async Task<Tournament> AddTournamentAsync(Tournament tournament)
			{
				var response = await _httpClient.PostAsJsonAsync(ApiUrl + $"/api/TournamentApi", tournament);
				response.EnsureSuccessStatusCode();

				return (await response.Content.ReadFromJsonAsync<Tournament>())!;
			}

			public async Task UpdateTournamentAsync(Guid id, Tournament tournament)
			{
				var response = await _httpClient.PutAsJsonAsync(ApiUrl + $"/api/TournamentApi/{id}", tournament);
				response.EnsureSuccessStatusCode();
			}

			public async Task DeleteTournamentAsync(Guid id)
			{
				var response = await _httpClient.DeleteAsync(ApiUrl + $"/api/TournamentApi/{id.ToString()}");
				response.EnsureSuccessStatusCode();
			}
	}
}

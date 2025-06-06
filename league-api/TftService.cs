using System.Text.Json;

namespace League_API_Console_App
{
    public class TftService
    {
        private readonly RiotClient _client;

        public TftService(RiotClient client) { _client = client; }

        public async Task<TftMatchDto> GetMatchDetailsAsync(string matchId)
        {
            string url = $"https://europe.api.riotgames.com/tft/match/v1/matches/{matchId}";
            string json = await _client.GetAsync(url);

            var match = JsonSerializer.Deserialize<TftMatchDto>(json);

            return match;
        }

        public async Task<List<string>> GetMatchIdsAsync(string puuid, int count = 5)
        {
            string url = $"https://europe.api.riotgames.com/tft/match/v1/matches/by-puuid/{puuid}/ids?count={count}";
            string json = await _client.GetAsync(url);

            var matchIds = JsonSerializer.Deserialize<List<string>>(json);
            return matchIds;
        }
    }
}

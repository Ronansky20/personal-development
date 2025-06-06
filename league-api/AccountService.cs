using System.Text.Json;

namespace League_API_Console_App
{
    public class AccountService
    {
        private readonly RiotClient _client;

        public AccountService(RiotClient client)
        {
            _client = client;
        }

        public async Task<string> GetPuuidAsync(string gameName, string tagLine)
        {
            string url = $"https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
            string json = await _client.GetAsync(url);

            var account = JsonSerializer.Deserialize<AccountDto>(json);
            return account.puuid;
        }
    }
}

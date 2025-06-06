namespace League_API_Console_App
{
    public class RiotClient
    {
        private readonly HttpClient _client;

        public RiotClient(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

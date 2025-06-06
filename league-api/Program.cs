using League_API_Console_App;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        EnvLoader.LoadEnv();

        Console.WriteLine("Enter User Name");
        string? gameName = Console.ReadLine();

        Console.WriteLine("Enter Tag");
        string? userTag = Console.ReadLine();

        string? apiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY");

        if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(gameName) || string.IsNullOrWhiteSpace(userTag))
        {
            Console.WriteLine("❌ Missing input.");
            return;
        }

        string region = "https://europe.api.riotgames.com";

        string requestUrl = $"{region}/riot/account/v1/accounts/by-riot-id/{gameName}/{userTag}";

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);

        try
        {

            HttpResponseMessage response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Raw JSON:");
            Console.WriteLine(json);

            RiotAccount? account = JsonSerializer.Deserialize<RiotAccount>(json);

            if (account != null)
            {
                Console.WriteLine($"PUUID for {account.gameName}#{account.tagLine}: {account.puuid}");
            }

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Error: {e.Message}");
        }
    }
}

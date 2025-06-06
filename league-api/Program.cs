using League_API_Console_App;

class Program
{
    static async Task Main(string[] args)
    {
        EnvLoader.LoadEnv();

        string? apiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY");

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("No API Key");
            return;
        }

        string region = "https://europe.api.riotgames.com";

        Console.WriteLine("Enter User Name");
        string? gameName = Console.ReadLine();
        Console.WriteLine("Enter Tag");
        string? userTag = Console.ReadLine();

        using HttpClient client = new HttpClient();

        try
        {
            string requestUrl = $"{region}/riot/account/v1/accounts/by-riot-id/{gameName}/{userTag}";
            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);

            HttpResponseMessage response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response:");
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Error: {e.Message}");
        }
    }
}
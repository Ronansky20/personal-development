using League_API_Console_App;

class Program
{
    static async Task Main(string[] args)
    {
        EnvLoader.LoadEnv();
        string? apiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY");

        var client = new RiotClient(apiKey);
        var accountService = new AccountService(client);
        var tftService = new TftService(client);

        Console.WriteLine("Enter Summoner Name");
        string gameName = Console.ReadLine();

        Console.WriteLine("Enter tag:");
        string tag = Console.ReadLine();

        string puuid = await accountService.GetPuuidAsync(gameName, tag);

        List<string> matchIds = await tftService.GetMatchIdsAsync(puuid);

        foreach (var matchId in matchIds)
        {
            var match = await tftService.GetMatchDetailsAsync(matchId);

            var player = match.info.participants.FirstOrDefault(p => p.puuid == puuid);

            if (player != null)
            {
                Console.WriteLine($"Match ID: {matchId}, Your Placement: {player.placement}");
            }

            else
            {
                Console.WriteLine($"Match ID: {matchId}, Your player was not found.");
            }
        }
    }
}
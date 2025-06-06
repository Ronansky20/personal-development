using DotNetEnv;

namespace League_API_Console_App
{
    public static class EnvLoader
    {
        public static void LoadEnv()
        {
            var envPath = FindEnvFile();
            if (envPath != null)
            {
                Env.Load(envPath);
                Console.WriteLine($"Loaded ENV from {envPath}");
            }
            else
            {
                Console.WriteLine("No ENV File found");
            }
        }

        private static string? FindEnvFile()
        {
            var current = new DirectoryInfo(AppContext.BaseDirectory);

            while (current != null)
            {
                var potentialPath = Path.Combine(current.FullName, ".env");
                if (File.Exists(potentialPath))
                    return potentialPath;

                current = current.Parent;
            }
            return null;
        }
    }
}

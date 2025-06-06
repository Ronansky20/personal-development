namespace League_API_Console_App
{
    public class TftMatchDto
    {
        public Metadata metadata { get; set; }
        public Info info { get; set; }
    }

    public class Metadata
    {
        public string data_version { get; set; }
        public string match_id { get; set; }
        public List<string> participants { get; set; }
    }

    public class Info
    {
        public long game_datetime { get; set; }
        public float game_length { get; set; }
        public string game_version { get; set; }
        public List<Participant> participants { get; set; }
    }

    public class Participant
    {
        public string puuid { get; set; }
        public int placement { get; set; }
        public int level { get; set; }
        public int last_round { get; set; }
        public float time_eliminated { get; set; }
        public int players_eliminated { get; set; }
        public List<Trait> traits { get; set; }
        public List<Unit> units { get; set; }
    }

    public class Trait
    {
        public string name { get; set; }
        public int num_units { get; set; }
        public int tier_current { get; set; }
        public int tier_total { get; set; }
    }

    public class Unit
    {
        public string character_id { get; set; }
        public List<int> items { get; set; }
        public int tier { get; set; }
    }
}

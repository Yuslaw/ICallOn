namespace api.Entities
{
    public class GameInitial
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Alphabet { get; set; }
        public Game Game { get; set; }
        public bool IsIPlayed { get; set; }
        public int? PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}
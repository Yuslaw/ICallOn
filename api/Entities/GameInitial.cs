namespace api.Entities
{
    public class GameInitial
    {
      public  int GameId { get; set; }
      public Initial Initial { get; set; }
      public int InitialId { get; set; }
      public Game Game { get; set; }
      public bool IsIncluded { get; set; }
      public bool IsIPlayed { get; set; }
      public int? PlayerId { get; set; }
      public Player? Player { get; set; }
    }
}
namespace api.Entities
{
    public class GameInitial
    {
<<<<<<< HEAD
      public int Id { get; set; }
=======
      public int Id {get;set;}
>>>>>>> 1008370a143ec106c9afe1f693bdb871e1809607
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
namespace api.Entities
{
    public class Entry
    {
        public  int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int InitialId { get; set; }
        public Initial Initial { get; set; }
        public string Value { get; set; }
        public double Score { get; set; }
    }
}
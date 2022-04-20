using api.Entities.Enums;

namespace api.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public string Alphabet { get; set; }
        public Category Category { get; set; }
        public string Value { get; set; }
        public double Score { get; set; }
    }
}
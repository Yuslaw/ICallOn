using System.Collections;
using System.Collections.Generic;

namespace api.Entities
{
    public class Player
    {
        public int  Id { get; set; }
        public int  GameId { get; set; }
        public string  Username { get; set; }
        public bool IsActive { get; set; }
        public int Score { get; set; }
        public bool IsCurrent  { get; set; }
        public IList<GameInitial> GameInitial { get; set;}
        public  Game Game { get; set; }
    }
}
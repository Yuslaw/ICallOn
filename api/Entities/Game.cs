using System;
using System.Collections.Generic;

namespace api.Entities
{
    public class Game
    {
        public int Id{get; set;}
        public string GameCode { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public  bool IsPlayed { get; set; }
        public DateTime CreatedTime { get; set; }
        public  bool IsStarted { get; set; }
        public IList<Player> Players { get; set; } = new List<Player>();
        public IList<Entry> Entries { get; set; } = new List<Entry>();
        public List<GameInitial> GameInitials { get; set; } = new List<GameInitial>();
    }
}
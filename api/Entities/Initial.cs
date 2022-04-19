using System.Collections.Generic;

namespace api.Entities
{
    public class Initial
    {
        public int Id {get; set;}
        public string Alphabets {get; set;}
        public List<GameInitial> GameInitial { get; set; } = new List<GameInitial>();
    }
}
using System.Collections.Generic;

namespace api.Entities
{
    public class Initial
    {
        public int Id {get; set;}
        public string Alphabets {get; set;}
<<<<<<< HEAD
        public IList<GameInitial> GameInitial { get; set; } = new List<GameInitial>();
=======
        public List<GameInitial> GameInitial {get; set;} = new List<GameInitial>();
>>>>>>> 6f2237ea1659c104d5b78f9a6c29b856754c263a
    }
}
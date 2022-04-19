using System.Collections.Generic;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IGameRepository
    {
        public Game AddGame(Game game);
        public Game UpdateGame(Game game);
        public bool DeleteGame(int id);
        public Game GetGame(int id);
        public IList<Game> GetAll();
        
        


    }
}
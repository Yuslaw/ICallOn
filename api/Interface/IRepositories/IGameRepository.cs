using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IGameRepository
    {
        public Task<Game> AddGame(Game game);
        public Task<Game> UpdateGame(Game game);
        public bool DeleteGame(Game game);
        public Task<Game> GetGame(int id);
        public Task<IList<Game>> GetAll();

        public Task<Game> GetGameByTitle( string title);
        public Task<IList<Player>> GetPlayersByGame(int id);


    }
}
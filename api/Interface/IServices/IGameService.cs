using System.Threading.Tasks;
using api.Dtos;

namespace api.Interface.IServices
{
    public interface IGameService
    {
        Task<GameResponseModel> AddGame(GameRequestModel request, int creatorId);
        Task<GameResponseModel> UpdateGame(GameRequestModel request, int id);
        Task<GameResponseModel> DeleteGame(int id);
        Task<GamesResponseModel> GetAllGames();
        Task<GameResponseModel> GetGame(int id);
        Task<GameResponseModel> GetGameByTitle(string title);
        Task<PlayersResponseModel> GetPlayersByGame(int id);
    }
}
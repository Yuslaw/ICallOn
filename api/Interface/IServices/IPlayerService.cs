using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interface.IServices
{
    public class IPlayerService
    {
        Task<BaseResponse> AddPlayer(CreatePlayerRequest player);
        Task<BaseResponse> UpdatePlayerProfile(UpdatePlayerRequest player);
        Task<BaseResponse> SetScore(int playerId);
         Task<BaseResponse> SetCurrentPlayerStatus(int playerId);
        Task<BaseResponse> MakePlayerActive(int playerId);
        Task<PlayerResponseModel> GetPlayerByUserName(string userName);
        Task<PlayersResponseModel> GetAllPlayers();
        Task<BaseResponse> DeletePlayer(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interface.IServices
{
    public interface IPlayerService
    {
        public Task<BaseResponse> AddPlayer(CreatePlayerRequest player);
        public Task<BaseResponse> UpdatePlayerProfile(UpdatePlayerRequest player);
        public Task<BaseResponse> SetScore(int playerId);
         public Task<BaseResponse> SetCurrentPlayerStatus(int playerId);
        public Task<BaseResponse> MakePlayerActive(int playerId);
        public Task<PlayerResponseModel> GetPlayerByUserName(string userName);
        public Task<PlayersResponseModel> GetAllPlayers();
        public Task<BaseResponse> DeletePlayer(int id);
    }
}
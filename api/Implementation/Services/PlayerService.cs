using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interface.IRepositories;
using api.Interface.IServices;

namespace api.Implementation.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        public PlayerService(IPlayerRepository playerRepository, IGameRepository gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }
        public async Task<BaseResponse> AddPlayer(CreatePlayerRequest player)
        {
              var game = await _gameRepository.GetGameByTitle(player.GameName); 
                if(game != null)
                {
                    var newplayer = new Player
                    {
                        GameId = game.Id,
                        Username = player.UserName,
                        IsCurrent = false,
                        Score = 0,
                        IsActive = true
                    };
                    await _playerRepository.AddPlayer(newplayer);
                    return new BaseResponse
                    {
                        Status = true,
                       Message = "Player successfully added"
                    };
                }
                 return new BaseResponse
                {
                    Status = false,
                    Message = "An error occured unable to add player"
                };   
        }
        public async Task<BaseResponse> MakePlayerActive(int playerId)
        {
            var checkPlayer = await _playerRepository.GetPlayer(x => x.Id == playerId);
             if (checkPlayer != null)
            {
                checkPlayer.IsActive = false;
                await _playerRepository.UpdatePlayer(checkPlayer);
                return new BaseResponse
                {
                    Status = true,
                    Message = $"{checkPlayer.Username} quit the game"
                };
            }
            return new BaseResponse
            {
                Status = false,
                Message = "Player not found"
            };
            
        
        }
        public async Task<BaseResponse> SetScore(int playerId)
        {
            var checkPlayer = await _playerRepository.GetPlayer(x => x.Id == playerId);
            if (checkPlayer != null)
            {
                checkPlayer.Score = checkPlayer.Score;
                await _playerRepository.UpdatePlayer(checkPlayer);
                return new BaseResponse
                {
                    Status = true,
                    Message = "This is player has a new score"
                };
            }
            return new BaseResponse
            {
                Status = false,
                Message = "Player not found"
            };
            
        }
        public async Task<BaseResponse> UpdatePlayerProfile(UpdatePlayerRequest player)
        {
            var checkPlayer = await _playerRepository.GetPlayer(x => x.Username == player.UserName);
            var game = await _gameRepository.GetGame(player.GameId); 
            if (checkPlayer != null)
            {
                checkPlayer.Username = player.UserName;
                checkPlayer.GameId = game.Id;
                return new BaseResponse
                {
                    Message = "Profile successfully updated",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Status = false,
                Message = "Player not found"
            };
        }
        public async Task<BaseResponse> SetCurrentPlayerStatus(int playerId)
        {
            var checkPlayer = await _playerRepository.GetPlayer(x => x.Id == playerId);
            if (checkPlayer != null)
            {
                if (checkPlayer.IsCurrent)
                {
                    checkPlayer.IsCurrent = false;
                    await _playerRepository.UpdatePlayer(checkPlayer);
                    return new BaseResponse
                    {
                        Status = true,
                        Message = "This is no more the current Player"
                    };
                }
                checkPlayer.IsCurrent = true;
                await _playerRepository.UpdatePlayer(checkPlayer);
                return new BaseResponse
                {
                    Status = true,
                    Message = "This is now the current Player"
                };
            }
            return new BaseResponse
            {
                Status = false,
                Message = "Player not found"
            };
            
        }
        public async Task<PlayerResponseModel> GetPlayerByUserName(string userName)
        {
             var checkPlayer = await _playerRepository.GetPlayer(x => x.Username == userName);
            if (checkPlayer != null)
            {
                return new PlayerResponseModel
                {
                    Data = new PlayerDto
                    {
                        UserName = checkPlayer.Username,
                        Score = checkPlayer.Score,
                        GameId = checkPlayer.GameId,
                    },
                    Status = true,
                    Message = "Player Available"
                };
            }
            return new PlayerResponseModel
            {
                Status = true,
                Message = "Player Available"
            };
        }
        public async Task<PlayersResponseModel> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllPlayers();
            var playerDto = players.Select(p => new PlayerDto {

               UserName = p.Username,
               GameId = p.GameId,
               Score = p.Score
            }).ToList();
            return new PlayersResponseModel
            {
                Data = playerDto,
                Message = "These are list of Players",
                Status = true
            };

        }
        public async Task<BaseResponse> DeletePlayer(int id)
        {
            var player = await _playerRepository.GetPlayer(p => p.Id == id);
            if (player != null)
            {
                await _playerRepository.DeletePlayer(player.Id);
                return new BaseResponse
                {
                    Message = "Player successfully removed",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Player not found",
                Status = false
            };
        }
    }
}
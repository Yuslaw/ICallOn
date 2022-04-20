using System;
using System.Collections.Generic;
using api.Dtos;
using api.Entities;
using api.Interface.IRepositories;
using api.Interface.IServices;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace api.Implementation.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;

        public GameService(IGameRepository gameRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }
        public async Task<GameResponseModel> AddGame(GameRequestModel request, int creatorId)
        {

            var creator = await _userRepository.GetUser(creatorId);

            if (creator == null) return new GameResponseModel
            {
                Status = false,
                Message = "User not found",
            };

            var game = new Game
            {
                Title = request.Title,
                CreatedTime = DateTime.Now,
                CreatorId = creatorId,
                GameCode = Guid.NewGuid().ToString().Substring(0, 4),
                IsPlayed = false,
                IsStarted = false
            };

            game.Players.Add(new Player
            {
                Username = creator.UserName,
                IsCurrent = true,
                IsActive = true,
                GameId = game.Id,
            });
            var add = await _gameRepository.AddGame(game);
            if (add != null)
            {
                return new GameResponseModel()
                {
                    Status = true,
                    Message = "Game Created Successfully",
                };
            }

            return new GameResponseModel
            {
                Status = false,
                Message = "Failed",
            };

        }

        public async Task<GameResponseModel> UpdateGame(GameRequestModel request, int id)
        {
            var getGame = await _gameRepository.GetGame(id);
            if (getGame != null)
            {
                getGame.Title = request.Title;
                var update = await _gameRepository.UpdateGame(getGame);
                return new GameResponseModel
                {
                    Status = true,
                    Message = "Updated Succesfully"
                };
            }

            return new GameResponseModel
            {
                Status = false,
                Message = "Update Failed",
            };
        }

        public async Task<GameResponseModel> DeleteGame(int id)
        {
            var getGame = await _gameRepository.GetGame(id);
            if (getGame != null)
            {
                var deleteGame = _gameRepository.DeleteGame(getGame);
                if (deleteGame)
                {
                    return new GameResponseModel()
                    {
                        Status = true,
                        Message = "Deleted Successfully"
                    };
                }
            }

            return new GameResponseModel()
            {
                Status = false,
                Message = "Failed"
            };
        }

        public async Task<GamesResponseModel> GetAllGames()
        {

            var getGames = (await _gameRepository.GetAll()).Select(game => new GameDto()
            {
                Id = game.Id,
                Title = game.Title,
                CreatedTime = game.CreatedTime,
                CreatorId = game.CreatorId,
                GameCode = game.GameCode,
                IsPlayed = game.IsPlayed,
                IsStarted = game.IsStarted,
            }).ToList();
            return new GamesResponseModel
            {
                Data = getGames,
            };
        }

        public async Task<GameResponseModel> GetGame(int id)
        {
            var getGame = await _gameRepository.GetGame(id);
            if (getGame != null)
            {
                return new GameResponseModel
                {
                    Status = true,
                    Message = "Successful",
                    Data = new GameDto
                    {
                        Id = getGame.Id,
                        Title = getGame.Title,
                        CreatedTime = getGame.CreatedTime,
                        CreatorId = getGame.CreatorId,
                        GameCode = getGame.GameCode,
                        IsPlayed = getGame.IsPlayed,
                        IsStarted = getGame.IsStarted,
                    }
                };
            }

            return new GameResponseModel
            {
                Status = false,
                Message = "Failed"
            };
        }

        public async Task<GameResponseModel> GetGameByTitle(string title)
        {
            var getGame = await _gameRepository.GetGameByTitle(title);
            if (getGame != null)
            {
                return new GameResponseModel
                {
                    Status = true,
                    Message = "Successful",
                    Data = new GameDto
                    {
                        Id = getGame.Id,
                        Title = getGame.Title,
                        CreatedTime = getGame.CreatedTime,
                        CreatorId = getGame.CreatorId,
                        GameCode = getGame.GameCode,
                        IsPlayed = getGame.IsPlayed,
                        IsStarted = getGame.IsStarted,
                    }
                };
            }

            return new GameResponseModel
            {
                Status = false,
                Message = "Failed"
            };
        }

        public async Task<PlayersResponseModel> GetPlayersByGame(int id)
        {
            var players = (await _gameRepository.GetPlayersByGame(id)).Select(s => new PlayerDto()
            {
                Id = s.Id,
                UserName = s.Username,
                Score = s.Score,
                GameId = s.Game.Id,
            }).ToList();
            return new PlayersResponseModel()
            {
                Data = players,
                Status = true,
            };
        }
    }
}
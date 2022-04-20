using System;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos;
using api.Interface.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        [HttpPost("game/newgame")]
        public async Task<IActionResult> AddGame([FromBody]GameRequestModel requestModel)
        {
            var gameCode = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var newGame = await _gameService.AddGame(requestModel, gameCode);
            if (newGame.Status)
            {
                return Ok(newGame.Message);
            }

            return BadRequest(newGame.Message);
        }

        [HttpGet("GetGameById")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameService.GetGame(id);
            if (game.Status)
            {
                return Ok(game.Data);
            }

            return NotFound(game.Message);
        }

        [HttpGet("GetGameTitle")]
        public async Task<IActionResult> GetGameByTitle(string title)
        {
            //string title = request.Title;
            var game = await _gameService.GetGameByTitle(title);
            if (game.Status)
            {
                return Ok(game.Data);
            }

            return BadRequest(game.Message);
        }

        [HttpGet("GetAllGames")]
        public async Task<IActionResult> GetAllGames()
        {
            var game = await _gameService.GetAllGames();
            if (game.Status)
            {
                return Ok(game.Data);
            }

            return BadRequest();
        }

        [HttpPost("UpdateGame")]
        public async Task<IActionResult> UpdateGame(GameRequestModel request, int id)
        {
            var game = await _gameService.UpdateGame(request, id);
            if (game.Status)
            {
                return Ok(game.Data);
            }

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var deleteGame = await _gameService.DeleteGame(id);
            if (deleteGame.Status)
            {
                return Ok(deleteGame.Message);
            }

            return Forbid(deleteGame.Message);
        }
        [HttpGet("Getplayers")]
        public async Task<IActionResult> GetPlayersByGame(int id)
        {
            var player = await _gameService.GetPlayersByGame(id);
            if (player.Status)
            {
                return Ok(player.Data);
            }

            return NotFound();
        }
    }
}
using System;
using System.Threading.Tasks;
using api.Dtos;
using api.Interface.IServices;
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
        [HttpPost ("game/newgame")]
        public async Task<IActionResult> AddGame(GameRequestModel requestModel, int gameCode)
        {
            gameCode = Convert.ToInt32(User.FindFirst("NameIdentify"));
            var newGame = await _gameService.AddGame(requestModel, gameCode);
            if (newGame.Status)
            {
                return Ok(newGame.Message);
            }

            return NotFound(newGame.Message);
        }
    }
}
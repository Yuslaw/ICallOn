using System;
using System.Threading.Tasks;
using api.Dtos;
using api.Interface.IServices;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService  _playerService;
       
        public PlayerController(IPlayerService playerService)
        {
             _playerService = playerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer(CreatePlayerRequest playerRequest)
        {
            
            var player = await _playerService.AddPlayer(playerRequest, User.Identity.IsAuthenticated);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayerProfile(UpdatePlayerRequest playerRequest)
        {
            var player = await _playerService.UpdatePlayerProfile(playerRequest);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();
        }
        [HttpPut("player/{playerId}")]
        public async Task<IActionResult> SetScore(int playerId)
        {
            var player = await _playerService.SetScore(playerId);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();
        }
        [HttpPut("player/{currentPlayerId}")]
        public async Task<IActionResult> SetCurrentPlayerStatus(int currentPlayerId)
        {
            var player = await _playerService.SetCurrentPlayerStatus(currentPlayerId);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();
        }
        [HttpPut("player/{activePlayerId}")]
        public async Task<IActionResult> MakePlayerActive(int activePlayerId)
        {
            var player = await _playerService.MakePlayerActive(activePlayerId);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();
        }
        [HttpGet("player/{userName}")]
        public async Task<IActionResult> GetPlayerByUserName(string userName)
        {
            var player = await _playerService.GetPlayerByUserName(userName);
            if (player.Status == true)
            {
                return Ok(player.Data);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var player = await _playerService.GetAllPlayers();
            if (player.Status == true)
            {
                return Ok(player.Data);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _playerService.DeletePlayer(id);
            if (player.Status == true)
            {
                return Ok(player);
            }
            return BadRequest();

        }
    }
}
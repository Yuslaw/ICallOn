using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Application;
using api.Entities;
using api.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace api.Implementation.Repositories
{
    public class PlayerRepository
    {
        private readonly Context _context;
        public PlayerRepository(Context context)
        {
            _context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            _context.SaveChanges();
            return player;
        }
        public Task<Player> UpdatePlayer(Player player)
        {
            var updatedPlayer = _context.Player.UpdateAsync(player);
            return updatedPlayer;
        }
        public async Task<Player> GetPlayer (Expression<Func<Player,bool>> expression)
        {
            var player = await _context.Players.SingleOrDefaultAsync(expression);
            return player;
        }
        public async Task<IList<Player>> GetAllPlayers()
        {
            var players = _context.Player.ToList();
            return players;
        }
        public async Task<bool> DeletePlayer(Player player)
        {
            _context.Players.RemoveAsync(player);
            return true;
        }
    }
}
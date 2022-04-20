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
        private readonly ApplicationContext _context;
        public PlayerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<Player> UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<Player> GetPlayer(Expression<Func<Player, bool>> expression)
        {
            var player = await _context.Players.SingleOrDefaultAsync(expression);
            return player;
        }
        public async Task<IList<Player>> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return players;
        }
        public async Task<bool> DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
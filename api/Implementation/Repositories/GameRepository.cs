using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application;
using api.Entities;
using api.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace api.Implementation.Repositories
{
    
    public class GameRepository: IGameRepository
    {
        private readonly ApplicationContext _context;

        public GameRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Game> AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> UpdateGame(Game game)
        {
             _context.Games.Update(game);
             await _context.SaveChangesAsync();
             return game;
        }

        public bool DeleteGame(Game game)
        {
            var del = _context.Games.Remove(game);
            _context.SaveChanges();
            return true;
        }

        public async Task<Game> GetGame(int id)
        {
           var game = await _context.Games.FindAsync(id);
           return game;

        }

        public async Task<IList<Game>> GetAll()
        {
            var game = await _context.Games.ToListAsync();
            return game;
        }

        public async Task<Game> GetGameByTitle(string title)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x=>x.Title==title);
            return game;
        }

        
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Interface.IRepositories;
using Api.Application;

namespace api.Implementation.Repositories
{
    public class GameInitialRepository : IGameInitialRepository
    {
        private readonly ApplicationContext _context;

        public GameInitialRepository(ApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<GameInitial>> AddInitials(List<GameInitial> initials)
        {
            await _context.GameInitials.AddRangeAsync(initials);

            await _context.SaveChangesAsync();

            return initials;

        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IGameInitialRepository
    {
        
         Task<List<GameInitial>> AddInitials(List<GameInitial> initials);
    }
}
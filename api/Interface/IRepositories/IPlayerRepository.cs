using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using System.Linq;
using System.Linq.Expressions;
using System;
namespace api.Interface.IRepositories
{
    public interface IPlayerRepository
    {
        Task<Player> AddPlayer(Player player);
        Task<Player> GetPlayer (Expression<Func<Player,bool>> expression);
        Task<IList<Player>> GetAllPlayers();
        Task<bool> DeletePlayer(int id);
        Task<Player> UpdatePlayer(Player player);
    }
}
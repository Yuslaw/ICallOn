using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IUserRepository
    {
        Task<User> ResgisterUser(User user);
        Task<bool> CheckUserName(string username);
        Task<User> GetUser(string username);
        Task<IList<User>> GetAllUsers();
        Task<User> Update(User user);
    }
}
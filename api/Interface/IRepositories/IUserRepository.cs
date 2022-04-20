using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IUserRepository
    {
        Task<User> ResgisterUser(User user);
        Task<bool> CheckUserName(string username);
        Task<User> GetUser(int id);
        Task<User> GetUser(string username);
        Task<IList<User>> GetAllUsers();
        User Update(User user);
        bool Delete (User user);
    }
}
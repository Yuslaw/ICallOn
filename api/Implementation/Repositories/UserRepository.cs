using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Interface.IRepositories;

namespace api.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> CheckUserName(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ResgisterUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
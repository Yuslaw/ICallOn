using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Interface.IRepositories;
using Api.Application;
using Microsoft.EntityFrameworkCore;

namespace api.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _Context;
        public UserRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> CheckUserName(string username)
        {
            var checkUserName = await _Context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
            return checkUserName;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var getAll = await _Context.Users.ToListAsync();
            return getAll;
        }

        public async Task<User> GetUser(string username)
        {
            var checkUserName = await _Context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower());
            return checkUserName;
        }

        public async Task<User> ResgisterUser(User user)
        {
           var create = await _Context.AddAsync(user);
           await _Context.SaveChangesAsync();
           return user;
        }

        public User Update(User user)
        {
           var update = _Context.Update(user);
           _Context.SaveChanges();
           return user;
        }

        public bool Delete(User user)
        {
            _Context.Remove(user);
            _Context.SaveChanges();
            return true;
        }

        public async Task<User> GetUser(int id)
        {
            return await _Context.Users.FindAsync(id);
        }
    }
}
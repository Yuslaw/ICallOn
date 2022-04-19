using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IUserRepository
    {
        User ResgisterUser(User user);
        bool CheckUserName(string username);
        
    }
}
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interface.IServices
{
    public interface IUserServices
    {
        Task<BaseResponse> ResgisterUser(UserRequestModel requestModel);
        Task<BaseResponse> GetUser(string username);
        Task<UsersResponseModel>  GetAllUsers();
       Task<BaseResponse> Update(UserRequestModel user);
       Task<BaseResponse> Login(UserLoginRequest loginRequest);
    }
}
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interface.IRepositories;
using api.Interface.IServices;

namespace api.Implementation.Services
{
    public class UserServices : IUserServices
    {
        public IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UsersResponseModel> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseResponse> GetUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseResponse> Login(UserLoginRequest loginRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BaseResponse> ResgisterUser(UserRequestModel requestModel)
        {
            var checkUserName = await _userRepository.CheckUserName(requestModel.UserName);
            if(checkUserName == true)
            {
                return new BaseResponse
                {
                    Message = "Username already exist",
                    Status = false,
                };
            }
            var resgisterUser = new User
            {
                UserName = requestModel.UserName,
                Password = requestModel.Password,
                Gender = requestModel.Gender,
                Avatar = requestModel.Avatar
            };
            var create = _userRepository.ResgisterUser(resgisterUser);
            if(create == null)
            {
               return new BaseResponse
                {
                    Message = "Unable to create",
                    Status = false,
                };
            }
            return new BaseResponse
            {
                Message = "Account Created",
                Status = true
            };
        }

        public Task<BaseResponse> Update(UserRequestModel user)
        {
            throw new System.NotImplementedException();
        }
    }
}
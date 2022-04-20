using System.Collections.Generic;
using System.Linq;
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

        public async Task<UsersResponseModel> GetAllUsers()
        {
            var allUsers = await _userRepository.GetAllUsers();
            var allUsersReturned = allUsers.Select(g=> new UserDto()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                Password = g.Password,
                UserName = g.UserName,
                Gender = g.Gender,
                Id = g.Id
            }).ToList();
            
            return new UsersResponseModel()
            {
                Status = true,
                Message= "Retrieval success",
                Data = allUsersReturned
            };
        }

        public async Task<UserResponseModel> GetUser(string username)
        {
            var getUser = await _userRepository.GetUser(username);
            if (getUser != null)
            {
                return new UserResponseModel()
                {
                    Message = "Account Found",
                    Status = true,
                    Data = new UserDto()
                    {
                        UserName = getUser.UserName,
                        Gender = getUser.Gender,
                        Id = getUser.Id,
                        Password = getUser.Password,
                        Avatar = getUser.Avatar,
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName
                    }
                };
            }

            return new UserResponseModel()
            {
                Message = "Account Not Found",
                Status = false
            };
        }

        public async Task<bool> Delete(string userName)
        {
            var getUser = await _userRepository.GetUser(userName);
            if (getUser==null)
            {
                return false;
            }
            _userRepository.Delete(getUser);
            return true;
        }

        public async Task<UserResponseModel> Login(UserLoginRequest loginRequest)
        {
            var getUser = await _userRepository.GetUser(loginRequest.UserName);
            
            if (getUser!=null && loginRequest.Password != null)
            {
                return new UserResponseModel()
                {
                    Message = "Login Found",
                    Status = true,
                    Data = new UserDto()
                    {
                        UserName = getUser.UserName,
                        Gender = getUser.Gender,
                        Id = getUser.Id,
                        Password = getUser.Password,
                        Avatar = getUser.Avatar,
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName
                    }
                };
            }

            return new UserResponseModel()
            {
                Message = "Invalid UserName or Password",
                Status = false
            };
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
                Avatar = requestModel.Avatar,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
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

        public async Task<BaseResponse> Update(UserRequestModel user)
        {
            var getUser = await _userRepository.GetUser(user.UserName);
            if (getUser==null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Account Not Found"
                };
            }
            getUser.LastName = user.LastName;
            getUser.Password = user.Password;
            getUser.FirstName = user.FirstName;
            _userRepository.Update(getUser);
            return new BaseResponse()
            {
                Status = false,
                Message = "Account Updated"
            };

        }
    }
}
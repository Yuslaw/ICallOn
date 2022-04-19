using System.Collections.Generic;

namespace api.Dtos
{
    public class UserDto
    {
        public int Id{get;set;}
        public string UserName{get;set;}
        public string Password{get;set;}
        public string Gender{get;set;}
        public string Avatar{get;set;}
    }
    public class UserRequestModel
    {
        public string UserName{get;set;}
        public string Password{get;set;}
        public string Gender{get;set;}
        public string Avatar{get;set;}
    }
    public class UserResponseModel : BaseResponse
    {
        public UserDto Data{get;set;}
    }
    public class UsersResponseModel : BaseResponse
    {
        public List<UserDto> Data{get;set;}
    }
    public class UserLoginRequest
    {
        public string UserName{get; set;}
        public string Password{get; set;}
    }
}
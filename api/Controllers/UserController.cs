using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userService;
        private IJwtAuthentication _authentication;
       
        public UserController(IUserServices userService, IJwtAuthentication authentication)
        {
            _userService = userService;
            _authentication = authentication;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreatUser([FromBody]UserRequestModel _request)
        {
            var create = await _userService.ResgisterUser(_request);
            if (create.Status)
            {
                return Ok(create); 
            }
            return BadRequest(create);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest _loginRequest)
        {
            var login = await _userService.Login(_loginRequest);
            if (login.Status!=true)
            {
                return BadRequest(login);
            }

            var userLoginResponse = new UserLoginResponse()
            {
                UserName = _loginRequest.UserName,
                Token = _authentication.GenerateToken(login.Data)
            };
            return Ok(userLoginResponse);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var getu = User.FindFirstValue(ClaimTypes.Name);
            var getUser = await _userService.GetUser(getu);
            if (getUser!=null)
            {
                return Ok(getUser);
            }

            return BadRequest();
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserRequestModel user)
        {
            var update = await _userService.Update(user);
            if (update!=null)
            {
                return Ok(update);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string user)
        {
            var delete = await _userService.Delete(user);
            if (delete)
            {
                return Ok(delete);
            }
            return BadRequest();
        }
    }
}
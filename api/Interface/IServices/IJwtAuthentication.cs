using api.Dtos;

namespace api.Interface.IServices
{
    public interface IJwtAuthentication
    {
         string GenerateToken(UserDto user);
    }
}
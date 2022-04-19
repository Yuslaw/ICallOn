using System.Collections;
using System.Collections.Generic;

namespace api.Dtos
{
    public class PlayerDto : BaseResponse
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public string  Score { get; set; }
        public string  GameName { get; set; }
        
        
    }

    public class CreatePlayerRequest
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public string  Score { get; set; }
        public int  GameId { get; set; }
        public string  GameName { get; set; }
    }
    
    public class UpdatePlayerRequest
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public int  GameId { get; set; }
    }
    
    public class PlayerResponseModel: BaseResponse
    {
        public PlayerDto Data { get; set; }
    }
    
    public class PlayersResponseModel: BaseResponse
    {
        public IList<PlayerDto> Data { get; set; }
    }
}
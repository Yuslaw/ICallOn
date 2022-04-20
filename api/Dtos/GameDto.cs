using System;
using System.Collections.Generic;
using api.Entities;

namespace api.Dtos
{
    public class GameDto
    {
        public int Id{get; set;}
        public string GameCode { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public  bool IsPlayed { get; set; }
        public DateTime CreatedTime { get; set; }
        public  bool IsStarted { get; set; }
    }

    public class GameRequestModel
    {
         public string Title { get; set; }
    }

    public class GameResponseModel:BaseResponse
    {
       public GameDto Data { get; set; } 
    }

    public class GamesResponseModel: BaseResponse
    {
        public IList<GameDto> Data { get; set; }
        
    }
    
    
}
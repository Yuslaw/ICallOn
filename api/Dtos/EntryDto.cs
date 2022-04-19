using System.Collections;
using System.Collections.Generic;
using api.Entities;

namespace api.Dtos
{
    public class EntryDto
    {
        public  int Id { get; set; }
        public string GameTitle { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string UserName { get; set; }
        public int InitialId { get; set; }
        public string Alphabet { get; set; }
        public string Value { get; set; }
        public double Score { get; set; }
    }

    public class EntryResponseModel : BaseResponse
    {
        public EntryDto Data { get; set; }
    }
    
    public class EntriesResponseModel : BaseResponse
    {
        public IList<EntryDto> Data { get; set; }
    }

    public class CreateEntryRequestModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int InitialId { get; set; }
        public string Value { get; set; }   
    }

    public class UpdateEntryRequestModel
    {
        public double Score { get; set; }
        public int EntryId { get; set; }
    }
}
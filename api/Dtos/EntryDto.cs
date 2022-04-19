using System.Collections.Generic;

namespace api.Dtos
{
    public class EntryDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int InitialId { get; set; }
        public string Value { get; set; }
    }

    public class CreateEntryRequestModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int InitialId { get; set; }
        public string Value { get; set; }
    }


    public class EntryResponseModel:BaseResponse
    {
        public EntryDto Data { get; set; }
    }


    public class EntrysResponseModel : BaseResponse
    {
        public IList<EntryDto> Data { get; set; }
    }


    public class UpdateEntryRequestModel
    {
        public double Score { get; set; }
    }
}

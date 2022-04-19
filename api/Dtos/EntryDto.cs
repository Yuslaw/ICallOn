<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using System.Collections;
using System.Collections.Generic;
using api.Entities;
>>>>>>> 30e37ed86e99accec6f38cae75de8206f581fb28

namespace api.Dtos
{
    public class EntryDto
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 30e37ed86e99accec6f38cae75de8206f581fb28
    {
        public IList<EntryDto> Data { get; set; }
    }

<<<<<<< HEAD
=======
    public class CreateEntryRequestModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int InitialId { get; set; }
        public string Value { get; set; }   
    }
>>>>>>> 30e37ed86e99accec6f38cae75de8206f581fb28

    public class UpdateEntryRequestModel
    {
        public double Score { get; set; }
<<<<<<< HEAD
    }
}
=======
        public int EntryId { get; set; }
    }
}
>>>>>>> 30e37ed86e99accec6f38cae75de8206f581fb28

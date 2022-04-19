using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interface.IServices
{
    public interface IEntryService
    {
        public Task<BaseResponse> CreateEntry(CreateEntryRequestModel model);
        public Task<BaseResponse> UpdateEntry(UpdateEntryRequestModel model);
        public Task<EntriesResponseModel> GetEntries();
    }
}
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
        public Task<EntryResponseModel> GetEntry(int id);
        public Task<EntriesResponseModel> GetEntriesByGameCode(string GameCode);

        public Task<EntriesResponseModel> GetEntriesByInitialAlphabetAsync(string Alphabet);   
    }
}
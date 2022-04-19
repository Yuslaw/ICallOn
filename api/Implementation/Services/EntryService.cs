using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interface.IRepositories;
using api.Interface.IServices;

namespace api.Implementation.Services
{
    public class EntryService:IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IGameRepository _gameRepository;

        public EntryService(IEntryRepository entryRepository,IGameRepository gameRepository)
        {
            _entryRepository = entryRepository;
            _gameRepository = gameRepository;
        }
        public async Task<BaseResponse> CreateEntry(CreateEntryRequestModel model)
        {
            var game = _gameRepository.GetGame(model.GameId);
            var entrys = new Entry
            {
                Game = game,
                PlayerId = model.PlayerId,
                Value = model.Value,
                
            };
            var entris =  await _entryRepository.CreateEntry(entrys);
            return new BaseResponse()
            {
                Message = $" Entry with game code{game.GameCode} is Created succesfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateEntry(UpdateEntryRequestModel model)
        {
            var entry =await _entryRepository.GetEntry(u => u.Id == model.EntryId);
            var sameValues = await _entryRepository.GetEntriesByExpression(x => x.Value == entry.Value);
            if (sameValues!=null)
            {
                foreach (var existingEntry in sameValues)
                {
                    existingEntry.Score = model.Score / 2;
                }
            }
            entry.Score = model.Score;
            
            var entrys = _entryRepository.UpdateEntry(entry);
            return new BaseResponse()
            {
               Message = $"Entry score is successfully updated to {entrys.Result.Score}"
            };

        }

        

       public  async Task<EntriesResponseModel> GetEntries()
       {
           var entries = await _entryRepository.GetEntries();
           return new EntriesResponseModel
           {
               Data = entries.Select(v=>new EntryDto
               {
                   Alphabet = v.Initial.Alphabets,
                   Score = v.Score,
                   GameId = v.GameId,
                   GameTitle = v.Game.Title,
                   PlayerId = v.PlayerId,
                   Value = v.Value,
                   InitialId = v.InitialId,
                   UserName = v.Player.Username,
                   Id = v.Id
                   
               }).ToList(),
                 Message="Successful",
                 Status = true

           };
       }

        public async Task<EntryResponseModel> GetEntry(int id)
        {
            var entry = await _entryRepository.GetEntry(E => E.Id == id);
            var entryDto = new EntryDto
            {
                Id = id,
                Alphabet = entry.Initial.Alphabets,
                GameId = entry.GameId,
                GameTitle = entry.Game.Title,
                InitialId = entry.InitialId,
                PlayerId = entry.PlayerId,
                Score = entry.Score,
                UserName = entry.Player.Username,
                Value = entry.Value,
            };
            return new EntryResponseModel
            {
                Data = entryDto,
                Message = "Successful Entry Retrieval",
                Status= true,
            };
        }

        public async Task<EntriesResponseModel> GetEntriesByGameCode(string GameCode)
        {
            var entries = await _entryRepository.GetEntriesByExpression(E => E.Game.GameCode == GameCode);
            return new EntriesResponseModel
            {
                Data = entries.Select(e => new EntryDto
                {
                    Alphabet = e.Initial.Alphabets,
                    GameId = e.Game.Id,
                    GameTitle = e.Game.Title,
                    Id = e.Id,
                    InitialId = e.InitialId,
                    PlayerId = e.PlayerId,
                    Score = e.Score,
                    UserName = e.Player.Username,
                    Value = e.Value,

                }).ToList(),
                Message = "Retrieval Successfull",
                Status = true,
            };
        }

        public async Task<EntriesResponseModel> GetEntriesByInitialAlphabetAsync(string Alphabet)

        {
            var entries = await _entryRepository.GetEntriesByExpression(E => E.Initial.Alphabets == Alphabet);
            return new EntriesResponseModel
            {
                Data = entries.Select(e => new EntryDto
                {
                    Alphabet = e.Initial.Alphabets,
                    GameId = e.Game.Id,
                    GameTitle = e.Game.Title,
                    Id = e.Id,
                    InitialId = e.InitialId,
                    PlayerId = e.PlayerId,
                    Score = e.Score,
                    UserName = e.Player.Username,
                    Value = e.Value,

                }).ToList(),
                Message = "Retrieval Successfull",
                Status = true,
            };
        }
    }
}
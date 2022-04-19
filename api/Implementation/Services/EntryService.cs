﻿using System;
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
        
    }
}
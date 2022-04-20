using api.Dtos;
using api.Entities.Enums;
using api.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }





        [HttpPost("CreateEntry")]
        public async Task<IActionResult> CreateEntry(CreateEntryRequestModel model)
        {
            var entry = await _entryService.CreateEntry(model);
            if(entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
              var categories = Enum.GetValues(typeof(Category)).Cast<Category>();

            var categoriesDto = categories.Select(s => new CategoriesDto
            {
                Id = (int) s,
                Name = s.ToString()
            }).ToList();

            return Ok(categoriesDto);
        }



        [HttpPut("UpdateEntry")]
        public async Task<IActionResult> UpdateEntry(UpdateEntryRequestModel model)
        {
            var entry = await _entryService.UpdateEntry(model);
            if (entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }




        [HttpGet("GetAllEntry")]
        public async Task<IActionResult> GetEntries()
        {
            var entry = await _entryService.GetEntries();
            if (entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }




        [HttpGet("GetEntryById")]
        public async Task<IActionResult> GetEntryById(int id)
        {
            var entry = await _entryService.GetEntry(id);
            if (entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }



        [HttpGet("GetEntryByGameCode")]
        public async Task<IActionResult> GetEntryByGameCode(string code)
        {
            var entry = await _entryService.GetEntriesByGameCode(code);
            if (entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }



        [HttpGet("GetEntryByInitialAlphabet")]
        public async Task<IActionResult> GetEntryByIntialAlphabet(char alphabet)
        {
            var entry = await _entryService.GetEntriesByInitialAlphabetAsync(alphabet);
            if (entry.Status)
            {
                return Ok(entry);
            }

            return BadRequest();
        }

    }
}

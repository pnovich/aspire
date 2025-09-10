using Microsoft.AspNetCore.Mvc;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Services;

namespace MyAspireApp.ApiService.Controllers;

    [ApiController]
    [Route("api/entries")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpPost]
        public IActionResult CreateEntry([FromBody] CreateEntryRequest entry)
        {
            var created = _entryService.CreateEntry(entry);
            return CreatedAtAction(nameof(CreateEntry), new { id = created.Id }, created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entry>> GetAllEntries()
        {
            var entries = _entryService.GetAllEntries();
            return Ok(entries);
        }
    }

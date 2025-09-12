using Microsoft.AspNetCore.Mvc;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Services;

namespace MyAspireApp.ApiService.Controllers;

    [ApiController]
    [Route("api/winners")]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService _winnerService;

        public WinnerController(IWinnerService winnerService)
        {
            _winnerService = winnerService;
        }

        [HttpPost]
        public IActionResult CreateWinner([FromBody] CreateWinnerRequest winner)
        {
            Winner created = _winnerService.CreateWinner(winner);
            return CreatedAtAction(nameof(CreateWinner), new { id = created.Id }, created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Winner>> GetAllWinners()
        {
            var winners = _winnerService.GetAllWinners();
            return Ok(winners);
        }
    }

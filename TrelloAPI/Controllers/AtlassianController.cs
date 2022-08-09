using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tundra.Application.Interfaces;

namespace Tundra.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlassianController : ControllerBase
    {
        private readonly ILogger<AtlassianController> _logger;

        private readonly IBoardsService _boards;
        public AtlassianController(ILogger<AtlassianController> logger, IBoardsService boards)
        {
            _boards = boards;
            _logger = logger;
        }

        [HttpGet("index")]
        public async Task<string> GetBoardsAsync()
        {
            var result = await _boards.GetBoardsAsync();
            return result;
        }

        [HttpGet("get-board-lists")]
        public async Task<string> GetBoardListsAsync(string boardId)
        {
            var result = await _boards.GetColumnsAsync(boardId);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardAsync(string cardName, string cardDescription, string columnId)
        {
            var result = await _boards.CreateCardAsync(cardName, cardDescription, columnId);
            return Ok();
        }
    }
}

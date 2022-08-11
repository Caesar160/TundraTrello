using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tundra.Application.Interfaces;

namespace Tundra.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlassianController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBoardsService _boards;
        public AtlassianController(IBoardsService boards, IMediator mediator)
        {
            _boards = boards;
            _mediator = mediator;
        }
    }
    
        [HttpGet("get-boards")]
        public async Task<string> GetBoardsAsync()
        {
            var result = await _boards.GetBoardsAsync();
            return result;
        }

        [HttpGet("get-lists")]
        public async Task<string> GetBoardListsAsync(string boardId)
        {
            var result = await _boards.GetColumnsAsync(boardId);
            return result;
        }

        [HttpPost("create-card")]
        public async Task<IActionResult> CreateCardAsync(string cardName, string cardDescription, string columnId)
        {
            var result = await _boards.CreateCardAsync(cardName, cardDescription, columnId);
            return Ok();
        }
    }
}

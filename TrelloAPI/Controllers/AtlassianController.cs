using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;
using Tundra.Application.Interfaces;

namespace Tundra.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlassianController : BaseApiController
    {
        private readonly IBoardsService _boards;

        public AtlassianController(IBoardsService boards)
        {
            _boards = boards;
        }

        [HttpPost("create-card")]
        public async Task<IActionResult> CreateCardAsync([FromBody] CreateCardCommand command)
        {
            var result = await this.Mediator.Send(command);
            return Ok();
        }
    }
}
    
      
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;

namespace Tundra.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : BaseApiController
    {
        public CardsController()
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCardAsync([FromBody] CreateCardCommand command)
        {
            await this.Mediator.Send(command);
            return Ok();
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;
using Tundra.Application.Models;

namespace Tundra.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : BaseApiController
    {
        private readonly IValidator<CreateCardCommand> validator;

        public CardsController(IValidator<CreateCardCommand> validator)
        {
            this.validator = validator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCardAsync([FromBody] CreateCardCommand command)
        {
            ValidationResult result = await validator.ValidateAsync(command);
            if (result.IsValid)
            {
                await this.Mediator.Send(command);
                return Ok();
            }
            return BadRequest("Card name and card description shouldn't be empty");
        }
    }
}
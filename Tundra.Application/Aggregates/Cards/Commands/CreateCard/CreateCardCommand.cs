using MediatR;
using Newtonsoft.Json;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommand : IRequest<Unit>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

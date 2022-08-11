using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommand : IRequest<Unit>
    {
        [JsonProperty("idList")]
        public string IdList { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }
    }
}

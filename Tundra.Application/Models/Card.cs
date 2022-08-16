using FluentValidation;
using Newtonsoft.Json;
using Tundra.Application.Models;

namespace Tundra.Application.Models
{
    public class Card
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }
    }
}

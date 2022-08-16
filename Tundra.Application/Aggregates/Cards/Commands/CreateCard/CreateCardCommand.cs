﻿using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;
using Tundra.Application.Models;

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


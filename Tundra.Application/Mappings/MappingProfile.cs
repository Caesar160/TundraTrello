using AutoMapper;
using Tundra.Application.Aggregates.Cards.Commands.CreateCard;
using Tundra.Application.Models;

namespace Tundra.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCardCommand, Card>();
        }
    }
}

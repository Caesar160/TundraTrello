using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tundra.Application.Interfaces;
using Tundra.Application.Models;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Unit>
    {
        private readonly IBoardsService boardsService;
        private IMapper mapper;

        public CreateCardCommandHandler(IBoardsService boardsService, IMapper mapper)
        {
            this.boardsService = boardsService;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = mapper.Map<Card>(request);
            await boardsService.CreateCardAsync(card);
            return Unit.Value;
        }
    }
}

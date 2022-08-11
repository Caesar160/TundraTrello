using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tundra.Application.Interfaces;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Unit>
    {
        private readonly IBoardsService boardsService;

        public CreateCardCommandHandler(IBoardsService boardsService)
        {
            this.boardsService = boardsService;
        }
        public async Task<Unit> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            await this.boardsService.CreateCardAsync(request.Name, request.Description);
            return Unit.Value;
        }
    }
}

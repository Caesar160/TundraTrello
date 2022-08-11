using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Unit>
    {
        public async Task<Unit> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}

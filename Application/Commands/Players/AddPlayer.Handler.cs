using MediatR;

namespace Application.Commands.Players
{
    class AddPlayerHandler : IRequestHandler<AddPlayer, Unit>
    {
        public Task<Unit> Handle(AddPlayer request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

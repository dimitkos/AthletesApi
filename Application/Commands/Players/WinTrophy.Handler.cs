using MediatR;

namespace Application.Commands.Players
{
    class WinTrophyHandler : IRequestHandler<WinTrophy, Unit>
    {
        public Task<Unit> Handle(WinTrophy request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

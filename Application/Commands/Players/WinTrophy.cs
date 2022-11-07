using MediatR;

namespace Application.Commands.Players
{
    public class WinTrophy : IRequest<Unit>
    {
        public long PlayerId { get; }

        public WinTrophy(long playerId)
        {
            PlayerId = playerId;
        }
    }
}

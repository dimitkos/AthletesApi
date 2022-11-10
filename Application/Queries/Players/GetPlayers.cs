using MediatR;
using Shared.Models.Players;

namespace Application.Queries.Players
{
    public class GetPlayers : IRequest<PlayerModel[]>
    {
        public IReadOnlyCollection<long> PlayerIds { get; }

        public GetPlayers(IReadOnlyCollection<long> playerIds)
        {
            PlayerIds = playerIds;
        }
    }
}

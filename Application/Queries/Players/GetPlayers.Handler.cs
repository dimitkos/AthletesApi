using Application.Infrastructure;
using MediatR;
using Shared.Models.Players;

namespace Application.Queries.Players
{
    class GetPlayersHandlerr : IRequestHandler<GetPlayers, PlayerModel[]>
    {
        private readonly IQueryPersistence<GetPlayers, PlayerModel[]> _queryPersistence;

        public GetPlayersHandlerr(IQueryPersistence<GetPlayers, PlayerModel[]> queryPersistence)
        {
            _queryPersistence = queryPersistence;
        }

        public async Task<PlayerModel[]> Handle(GetPlayers request, CancellationToken cancellationToken)
            => await _queryPersistence.Fetch(request);
    }
}

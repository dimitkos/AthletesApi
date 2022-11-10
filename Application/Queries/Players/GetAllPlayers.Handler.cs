using Application.Infrastructure;
using MediatR;
using Shared.Models.Players;

namespace Application.Queries.Players
{
    class GetAllPlayersHandler : IRequestHandler<GetAllPlayers, PlayerModel[]>
    {
        private readonly IQueryPersistence<GetAllPlayers, PlayerModel[]> _queryPersistence;

        public GetAllPlayersHandler(IQueryPersistence<GetAllPlayers, PlayerModel[]> queryPersistence)
        {
            _queryPersistence = queryPersistence;
        }

        public async Task<PlayerModel[]> Handle(GetAllPlayers request, CancellationToken cancellationToken)
            => await _queryPersistence.Fetch(request);
    }
}

using Application.Infrastructure;
using MediatR;

namespace Application.Queries.Players
{
    class SearchPlayersHandler : IRequestHandler<SearchPlayers, long[]>
    {
        private readonly IQueryPersistence<SearchPlayers, long[]> _queryPersistence;

        public SearchPlayersHandler(IQueryPersistence<SearchPlayers, long[]> queryPersistence)
        {
            _queryPersistence = queryPersistence;
        }

        public Task<long[]> Handle(SearchPlayers request, CancellationToken cancellationToken)
            => _queryPersistence.Fetch(request);
    }
}

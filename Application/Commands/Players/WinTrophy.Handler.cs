using Application.Infrastructure;
using Application.Utils.Keys;
using Domain.Aggregates;
using Domain.Models;
using MediatR;

namespace Application.Commands.Players
{
    class WinTrophyHandler : IRequestHandler<WinTrophy, Unit>
    {
#warning add logger
        private readonly IDomainModelPersistence<WinTrophyDomainModel> _persistence;
        private readonly ICacheAdapter<Key<long>, Player> _cache;

        public WinTrophyHandler(IDomainModelPersistence<WinTrophyDomainModel> persistence, ICacheAdapter<Key<long>, Player> cache)
        {
            _persistence = persistence;
            _cache = cache;
        }

        public async Task<Unit> Handle(WinTrophy request, CancellationToken cancellationToken)
        {
            var player = await _cache.TryGet(new Key<long>(request.PlayerId));

            if (player is null)
                throw new Exception($"Player with id:{request.PlayerId} does not exist");

            var model = player.WinTrophy();
            await _persistence.Persist(model);

            return Unit.Value;
        }
    }
}

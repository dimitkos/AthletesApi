using Application.Infrastructure;
using Application.Utils.Keys;
using Domain.Aggregates;
using Domain.Models;
using MediatR;

namespace Application.Commands.Players
{
    class AddPlayerHandler : IRequestHandler<AddPlayer, Unit>
    {
#warning add logger
        private readonly IDomainModelPersistence<AddPlayerDomainModel> _persistence;
        private readonly ICacheAdapter<Key<long>, Player> _cache;

        public AddPlayerHandler(IDomainModelPersistence<AddPlayerDomainModel> persistence, ICacheAdapter<Key<long>, Player> cache)
        {
            _persistence = persistence;
            _cache = cache;
        }

        public async Task<Unit> Handle(AddPlayer request, CancellationToken cancellationToken)
        {
#warning maybe is better to use an interface instead of 
            var model = Player.CreatePlayer(request.Name, request.PhoneNumber);

            await _persistence.Persist(model);
            await _cache.Add(new Key<long>(model.Player.Id), model.Player);

            return Unit.Value;
        }
    }
}

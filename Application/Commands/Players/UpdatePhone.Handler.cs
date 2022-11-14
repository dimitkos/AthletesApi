using Application.Infrastructure;
using Application.Services;
using Application.Utils.Keys;
using Domain.Aggregates;
using Domain.Models;
using MediatR;

namespace Application.Commands.Players
{
    class UpdatePhoneHandler : IRequestHandler<UpdatePhone, Unit>
    {
#warning add logger
        private readonly IDomainModelPersistence<UpdatePhoneDomainModel> _persistence;
        private readonly ICacheAdapter<Key<long>, Player> _cache;
        private readonly IEntityRetrievalService<Key<long>, Player> _retrieve;

        public UpdatePhoneHandler(
            IDomainModelPersistence<UpdatePhoneDomainModel> persistence,
            ICacheAdapter<Key<long>, Player> cache,
            IEntityRetrievalService<Key<long>, Player> retrieve)
        {
            _persistence = persistence;
            _cache = cache;
            _retrieve = retrieve;
        }

        public async Task<Unit> Handle(UpdatePhone request, CancellationToken cancellationToken)
        {
            var key = new Key<long>(request.PlayerId);
            var player = await _retrieve.Retrieve(key);

            var model = player.UpdatePhone(request.PhoneNumber);

#warning may use an interface store
            await _persistence.Persist(model);
            await _cache.Add(key, model.Player);

            return Unit.Value;
        }
    }
}

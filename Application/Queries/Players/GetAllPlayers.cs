using MediatR;
using Shared.Models.Players;

namespace Application.Queries.Players
{
    public class GetAllPlayers : IRequest<PlayerModel[]>
    {
#warning consider add paging
    }
}

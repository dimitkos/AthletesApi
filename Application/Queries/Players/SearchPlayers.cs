using MediatR;

namespace Application.Queries.Players
{
    public class SearchPlayers : IRequest<long[]>
    {
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }
        public int? TrophiesFrom { get; }
        public int? TrophiesTo { get; }
        public int? Skip { get; }
        public int? Take { get; }

        public SearchPlayers(DateTime? dateFrom = null, DateTime? dateTo = null, int? trophiesFrom = null, int? trophiesTo = null, int? skip = null, int? take = null)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            TrophiesFrom = trophiesFrom;
            TrophiesTo = trophiesTo;
            Skip = skip;
            Take = take;
        }
    }
}

namespace Application.Infrastructure
{
    public interface IQueryPersistence<TRequest, TResult>
    {
        Task<TResult> Fetch(TRequest query);
    }
}

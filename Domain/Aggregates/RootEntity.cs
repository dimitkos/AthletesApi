namespace Domain.Aggregates
{
    public interface IRootEntity
    {
    }

    public abstract class RootEntity<TKey> : IRootEntity
    {
        public TKey Id { get; }

        protected RootEntity(TKey id)
        {
            Id = id;
        }
    }
}

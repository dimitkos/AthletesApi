namespace Domain.Aggregates
{
    public interface IRootEntity<TKey>
    {
        public TKey Id { get; }
    }

    public abstract class RootEntity<TKey> : IRootEntity<TKey>
    {
        public TKey Id { get; }

        protected RootEntity(TKey id)
        {
            Id = id;
        }
    }
}

namespace Application.Utils.Keys
{
#warning check this implementation
    //public interface IKey<T> 
    //{
    //    public T Value { get; }
    //}

    public struct Key<T> /*: IKey<T>*/
    {
        public T Value { get; }

        public Key(T value)
        {
            Value = value;
        }
    }
}

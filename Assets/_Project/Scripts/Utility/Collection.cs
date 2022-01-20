namespace CookRun.Utility
{
    public class Collection<T>
    {
        protected T[] _value;

        public Collection(T[] value)
        {
            _value = value;
        }

        public T[] Value
        {
            get => _value;
            set => _value = value;
        }

        public T this[int i]
        {
            get { return _value[i]; }
            set { _value[i] = value; }
        }
    }
}
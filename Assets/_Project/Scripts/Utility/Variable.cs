namespace CookRun.Utility
{
    public class Variable<T>
    {
        protected T _value;
        protected bool _resetAfterReceive = false;

        /// <param name="value">Value to set</param>
        /// <param name="resetAfterReceive">Should the value of the variable "Value" be reseted after receiving it from "get" statement in the "Value" property?</param>
        public Variable(T value, bool resetAfterReceive = false)
        {
            _value = value;
            _resetAfterReceive = resetAfterReceive;
        }

        public T Value
        {
            get
            {
                if (!_resetAfterReceive)
                    return _value;

                T previous = _value;
                _value = default;
                return previous;
            }
            set => _value = value;
        }
    }
}
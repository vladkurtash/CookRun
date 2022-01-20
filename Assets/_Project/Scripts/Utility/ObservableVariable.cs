using System;

namespace CookRun.Utility
{
    public class ObservableVariable<T> where T : IEquatable<T>
    {
        protected T _value;

        public ObservableVariable(T value)
        {
            _value = value;
        }

        public event Action ValueChanged;

        public virtual T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                    return;

                _value = value;
                ValueChanged?.Invoke();
            }
        }

        protected void OnValueChanged()
        {
            ValueChanged?.Invoke();
        }
    }
}
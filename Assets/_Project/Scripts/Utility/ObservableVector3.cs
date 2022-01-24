using System;
using UnityEngine;

namespace CookRun.Utility
{
    public class ObservableVector3 : ObservableVariable<Vector3>
    {
        public ObservableVector3(Vector3 value) : base(value)
        { }

        public float X
        {
            get => _value.x;
            set { if (_value.x == value) return; _value.x = value; OnValueChanged(); }
        }
        public float Y
        {
            get => _value.y;
            set { if (_value.y == value) return; _value.y = value; OnValueChanged(); }
        }
        public float Z
        {
            get => _value.z;
            set { if (_value.z == value) return; _value.z = value; OnValueChanged(); }
        }

        public float this[int i]
        {
            get { return _value[i]; }
            set { _value[i] = value; }
        }
    }
}
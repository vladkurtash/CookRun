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
            set { _value.x = value; OnValueChanged(); }
        }
        public float Y
        {
            get => _value.y;
            set { _value.y = value; OnValueChanged(); }
        }
        public float Z
        {
            get => _value.z;
            set { _value.z = value; OnValueChanged(); }
        }

        public float this[int i]
        {
            get { return _value[i]; }
            set { _value[i] = value; }
        }
    }
}
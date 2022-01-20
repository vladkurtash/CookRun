using UnityEngine;

namespace CookRun.Utility
{
    public class Vector3Variable : Variable<Vector3>
    {
        /// <param name="value">Value to set</param>
        /// <param name="resetAfterReceive">Should the value of the variable "Value" be reseted after receiving it from "get" statement in the "Value" property?</param>
        public Vector3Variable(Vector3 value, bool resetAfterReceive = false) : base(value, resetAfterReceive)
        { }

        public float X { get => _value.x; set => _value.x = value; }
        public float Y { get => _value.y; set => _value.y = value; }
        public float Z { get => _value.z; set => _value.z = value; }

        public float this[int i]
        {
            get { return _value[i]; }
            set { _value[i] = value; }
        }
    }
}
using UnityEngine;

namespace CookRun.Utility
{
    public static class Vector
    {
        public static float GetAngle0360(Vector3 from, Vector3 to, Vector3 axis)
        {
            float angle = Vector3.SignedAngle(from, to, axis);

            if (angle < 0)
            {
                angle = 360 - (angle * -1);
            }

            return angle;
        }
    }
}
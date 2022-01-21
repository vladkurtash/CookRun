namespace CookRun.Systems
{
    public interface ISystemData
    { }

    public class MoveSystemData : ISystemData
    {
        public float speedForwardMax = 1.0f;
        public float speedHorizontalMax = 1.0f;
        public float accelerationTime = 1.0f;
        public float decelerationTime = 0.1f;
    }

    public class RotateSystemData : ISystemData
    {
        public float rotateSpeedMax = 0.0f;
        public float alignmentTime = 0.0f;
        public float accelerationTime = 0.0f;
        public float decelerationTime = 0.0f;
    }
}
namespace CookRun.Systems
{
    public class PlayerMovementSystem : IPlayerMovementSystem
    {
        private readonly IMoveSystem _moveSystem;
        private readonly IRotateSystem _rotateSystem;

        public PlayerMovementSystem(IMoveSystem moveSystem, IRotateSystem rotateSystem)
        {
            _moveSystem = moveSystem;
            _rotateSystem = rotateSystem;
        }

        public void Accelerate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void Decelerate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void PerformMovement()
        {
            
        }

        public void SetHorizontalDelta(float delta)
        {
            
        }
    }

    public interface IPlayerMovementSystem : IMovementSystem
    {
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
        void SetHorizontalDelta(float delta);
        void PerformMovement();
    }

    public interface IMovementSystem : ISystem
    {
        
    }
}
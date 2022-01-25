using System;
using CookRun.Core;

namespace CookRun.Systems
{
    /// <summary>
    /// Class used as the 'Facade' design pattern for Player movement systems (Move and Rotate systems).
    /// </summary>
    public class PlayerMovementSystem : IPlayerMovementSystem
    {
        private readonly IPlayerMoveSystem _moveSystem = null;
        private readonly IPlayerRotateSystem _rotateSystem = null;

        public PlayerMovementSystem(IPlayerMoveSystem moveSystem, IPlayerRotateSystem rotateSystem)
        {
            _moveSystem = moveSystem;
            _rotateSystem = rotateSystem;
            _moveSystem.Moving += OnMoving;
            _moveSystem.Standing += OnStanding;
        }

        public event Action Moving;
        public event Action Standing;

        private void OnMoving()
        {
            Moving?.Invoke();
        }

        private void OnStanding()
        {
            Standing?.Invoke();
        }

        public void UpdateLocal(float deltaTime)
        {
            _moveSystem.UpdateLocal(deltaTime);
            _rotateSystem.UpdateLocal(deltaTime);
        }

        public void Accelerate(float deltaTime)
        {
            _moveSystem.Accelerate(deltaTime);
            _rotateSystem.Accelerate(deltaTime);
        }

        public void Decelerate(float deltaTime)
        {
            _moveSystem.Decelerate(deltaTime);
            _rotateSystem.Decelerate(deltaTime);
        }

        public void Pause()
        {
            _moveSystem.Pause();
            _rotateSystem.Pause();
        }

        public void SetHorizontalDelta(float delta)
        {
            _moveSystem.HorizontalDelta = delta;
            _rotateSystem.HorizontalDelta = delta;
        }

        public void Unpause()
        {
            _moveSystem.Unpause();
            _rotateSystem.Unpause();
        }

        public void Stop()
        {
            _moveSystem.Stop();
            _rotateSystem.Stop();
        }
    }

    public interface IPlayerMovementSystem : IMovementSystem
    {
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
        void SetHorizontalDelta(float delta);
    }

    public interface IMovementSystem : ISystem, IUpdatable
    {
        event Action Moving;
        event Action Standing;
    }
}
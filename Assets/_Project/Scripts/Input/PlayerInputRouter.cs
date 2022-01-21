using UnityEngine;
using CookRun.Systems;
using CookRun.Core;

namespace CookRun.Input
{
    public class PlayerInputRouter : IInputRouter
    {
        private readonly ISlidingArea _slidingArea = null;
        private readonly IPlayerMovementSystem _movementSystem = null;
        private State _localState = State.Disable;

        public PlayerInputRouter(ISlidingArea slidingArea, IPlayerMovementSystem movementSystem)
        {
            _slidingArea = slidingArea;
            _movementSystem = movementSystem;
        }

        enum State
        {
            Enable,
            Disable
        }

        public void OnEnable() => _localState = State.Enable;
        public void OnDisable() => _localState = State.Disable;

        public void UpdateLocal(float deltaTime)
        {
            if(_localState == State.Disable)
                return;

            // if slidingArea gameObject is pressing 
            if (_slidingArea.PointerActive)
            {
                _movementSystem.Accelerate(deltaTime);
            }
            else
            {
                _movementSystem.Decelerate(deltaTime);
            }

            _movementSystem.SetHorizontalDelta(_slidingArea.PointerDelta.x);
        }
    }
}
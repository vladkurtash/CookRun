using UnityEngine;
using CookRun.Systems;
using CookRun.Model;

namespace CookRun.Input
{
    public class PlayerInputRouter : IInputRouter
    {
        private readonly ISlidingArea _slidingArea = null;
        private readonly IPlayerMoveSystem _moveSystem = null;
        private readonly IPlayerRotateSystem _rotateSystem = null;
        private readonly PlayerConfigData _configData = null;
        private State _localState = State.Disable;

        public PlayerInputRouter
            (ISlidingArea slidingArea, IPlayerMoveSystem moveSystem, 
            IPlayerRotateSystem rotateSystem, PlayerConfigData configData)
        {
            _slidingArea = slidingArea;
            _moveSystem = moveSystem;
            _rotateSystem = rotateSystem;
            _configData = configData;
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
            if (_localState == State.Disable)
                return;

            // if slidingArea gameObject is pressing 
            if (_slidingArea.PointerActive)
            {
                _moveSystem.Accelerate(deltaTime);
                _rotateSystem.Accelerate(deltaTime);
            }
            else
            {
                _moveSystem.Decelerate(deltaTime);
                _rotateSystem.Decelerate(deltaTime);
            }
            if (_slidingArea.PointerDelta.x == 0.0f)
            {
                _rotateSystem.Align(deltaTime);
            }
                
            float delta = _slidingArea.PointerDelta.x;
            _moveSystem.MoveHorizontal(delta * _configData.moveSensivity);
            _rotateSystem.Rotate(delta * _configData.rotateSensivity);
        }
    }
}
using CookRun.Core;
using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerFinishAutoPilot : IPlayerFinishAutoPilot
    {
        private PlayerFinishAutoPilotData _systemData = null;
        private IPlayerMoveSystem _moveSystem = null;
        private IPlayerRotateSystem _rotateSystem = null;
        private IMove _moveData = null;
        private State _state = State.Disable;
        private Phase _phase = Phase.None;

        public PlayerFinishAutoPilot
            (PlayerFinishAutoPilotData systemData, IPlayerMoveSystem moveSystem, 
            IPlayerRotateSystem rotateSystem, IMove moveData)
        {
            _systemData = systemData;
            _moveSystem = moveSystem;
            _rotateSystem = rotateSystem;
            _moveData = moveData;
        }

        private enum State
        {
            Enable,
            Disable
        }

        private enum Phase
        {
            None,
            MoveForward,
            Turn180Degrees
        }

        public void Perform()
        {
            _state = State.Enable;
            _phase = Phase.MoveForward;
            SetupMovementSystem();
        }

        public void UpdateLocal(float deltaTime)
        {
            if (_state == State.Disable)
                return;

            if (_phase == Phase.MoveForward)
            {
                PerformMovement(deltaTime);
                _rotateSystem.Align(deltaTime);
            }
            else if(_phase == Phase.Turn180Degrees)
            {
                _rotateSystem.Rotate(_systemData.rotationSpeed * deltaTime);
            }
        }

        private void SetupMovementSystem()
        {
            _moveSystem.SetAcceleration(1.0f);
            _moveSystem.SetForwardSpeedMax(_systemData.speedForwardMax);
        }

        private void PerformMovement(float deltaTime)
        {
            if (!InRoadCenter())
                MoveToRoadCenter(deltaTime);
        }

        private void MoveToRoadCenter(float deltaTime)
        {
            float currentX = _moveData.Position.x;
            float delta = Mathf.MoveTowards(0.0f, currentX, _systemData.speedHorizontalMax * deltaTime);
            // float delta = Mathf.Lerp(0.0f, currentX, _systemData.speedHorizontalMax * deltaTime);

            _moveSystem.MoveHorizontal(-delta);
        }

        private bool InRoadCenter() =>
            Mathf.Approximately(_moveData.Position.x, 0.0f);

        public void StopMovementAndTurn180()
        {
            _phase = Phase.Turn180Degrees;
            _rotateSystem.SetThreshold(180.0f);
            _rotateSystem.SetAcceleration(1.0f);
            _moveSystem.SetAcceleration(0.0f);
        }

        public void Pause() =>
            throw new System.NotImplementedException();
        public void Stop() =>
            throw new System.NotImplementedException();
        public void Unpause() =>
            throw new System.NotImplementedException();
    }

    public interface IPlayerFinishAutoPilot : ISystem, IUpdatable
    {
        void Perform();
        void StopMovementAndTurn180();
    }
}
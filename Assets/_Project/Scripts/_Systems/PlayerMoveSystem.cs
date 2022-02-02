using System;
using CookRun.Core;
using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerMoveSystem : AStandartMovementSystem<PlayerMoveSystemData, IMove>, IPlayerMoveSystem
    {
        private float _acceleration = 0.0f;
        private float _forwardSpeedMax = 0.0f;

        public PlayerMoveSystem(PlayerMoveSystemData systemData, IMove moveData) : base(systemData, moveData)
        {
            _forwardSpeedMax = systemData.speedForwardMax;
        }

        public event Action Moving;
        public event Action Standing;

        public override void Accelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(deltaTime / _systemData.accelerationTime);

        public override void Decelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(-(deltaTime / _systemData.decelerationTime));

        protected override void PerformMovement(float deltaTime)
        {
            MoveForward();

            if (Mathf.Approximately(_acceleration, 0.0f))
                Standing?.Invoke();
            else
                Moving?.Invoke();

            _modelData.ApplyChangePosition(_delta.Value);
            _delta.Value = Vector3.zero;
        }

        private void MoveForward() =>
            _delta.Z = _forwardSpeedMax * _acceleration;

        public void MoveHorizontal(float delta)
        {
            if (delta != 0.0f)
                _delta.X = _acceleration * delta;
        }

        private void ApplyChangeMaxSpeedPercentage(float value) =>
            _acceleration = Mathf.Clamp(_acceleration + value, 0.0f, 1.0f);

        public void SetAcceleration(float acceleraion) => _acceleration = Mathf.Clamp01(acceleraion);
        public void SetForwardSpeedMax(float speedMax) => _forwardSpeedMax = speedMax;
    }

    public interface IPlayerMoveSystem : IMoveSystem, IUpdatable
    {
        void MoveHorizontal(float delta);
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
        /// <param name="acceleraion">measures from 0 to 1</param>
        void SetAcceleration(float acceleraion);
        void SetForwardSpeedMax(float speedMax);
    }
}
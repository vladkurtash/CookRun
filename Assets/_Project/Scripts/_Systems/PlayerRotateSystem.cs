using System;
using CookRun.Core;
using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerRotateSystem : AStandartMovementSystem<PlayerRotateSystemData, IPlayerRotate>, IPlayerRotateSystem
    {
        private float _acceleration = 0.0f;
        private float _threshold = 0.0f;

        public PlayerRotateSystem(PlayerRotateSystemData systemData, IPlayerRotate modelData) : base(systemData, modelData)
        {
            _threshold = systemData.defaultYThreshold;
        }

        public override void Accelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(deltaTime / _systemData.accelerationTime);

        public override void Decelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(-(deltaTime / _systemData.decelerationTime));

        protected override void PerformMovement(float deltaTime)
        {
            EnsureThresholdIsNotExceeded();
            _modelData.ApplyChangeRotation(_delta.Value);
        }

        private void EnsureThresholdIsNotExceeded()
        {
            if (Mathf.Abs(_modelData.Rotataion.y + _delta.Value.y) > _threshold)
            {
                float sumY = _modelData.Rotataion.y + _delta.Value.y;
                float remainder = sumY - _threshold * Mathf.Sign(sumY);
                _delta.Y -= remainder;
            }
        }

        public void Align(float deltaTime)
        {
            if (Aligned() || deltaTime == 0.0f)
                return;

            _delta.Y = -(_modelData.Rotataion.y * (deltaTime / _systemData.alignmentTime));

            bool Aligned() => Mathf.Approximately(_modelData.Rotataion.y, 0.0f);
        }

        private void ApplyChangeMaxSpeedPercentage(float value) =>
            _acceleration = Mathf.Clamp(_acceleration + value, 0.0f, 1.0f);

        public void Rotate(float delta)
        {
            if (delta != 0.0f)
                _delta.Y = _acceleration * delta;
        }

        public void SetAcceleration(float acceleraion) => _acceleration = Mathf.Clamp01(acceleraion);
        public void SetThreshold(float threshold) => _threshold = threshold;
    }

    public interface IPlayerRotateSystem : IRotateSystem, IUpdatable
    {
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
        void Align(float deltaTime);
        void Rotate(float delta);
        /// <param name="acceleraion">measures from 0 to 1</param>
        void SetAcceleration(float acceleraion);
        void SetThreshold(float threshold);
    }
}
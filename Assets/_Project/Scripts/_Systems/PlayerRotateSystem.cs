using CookRun.Core;
using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerRotateSystem : AStandartMovementSystem<PlayerRotateSystemData, IPlayerRotate>, IPlayerRotateSystem
    {
        private float _acceleration = 0.0f;

        public PlayerRotateSystem(PlayerRotateSystemData systemData, IPlayerRotate modelData) : base(systemData, modelData)
        { }

        public float HorizontalDelta { set; private get; }

        public override void Accelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(deltaTime / _systemData.accelerationTime);

        public override void Decelerate(float deltaTime)
        {
            ApplyChangeMaxSpeedPercentage(-(deltaTime / _systemData.decelerationTime));
        }

        protected override void PerformMovement(float deltaTime)
        {
            RotateHorizontal(deltaTime);
            _modelData.ApplyChangeRotation(_delta.Value);
        }

        private void RotateHorizontal(float deltaTime)
        {
            if (InputHorizontalDelta())
                DoHorizontalRotation();
        }

        public void Align(float deltaTime)
        {
            if (Aligned())
                return;

            _delta.Y = -(_modelData.HorizontalRotationAxis * (deltaTime / _systemData.alignmentTime));

            bool Aligned() => Mathf.Approximately(_modelData.HorizontalRotationAxis, 0.0f);
        }

        private void ApplyChangeMaxSpeedPercentage(float value) =>
            _acceleration = Mathf.Clamp(_acceleration + value, 0.0f, 1.0f);

        private void DoHorizontalRotation() =>
            _delta.Y = _systemData.rotateSpeedMax * _acceleration * HorizontalDelta;

        private bool InputHorizontalDelta() => !Mathf.Approximately(HorizontalDelta, 0.0f);
    }

    public interface IPlayerRotateSystem : IRotateSystem, IUpdatable
    {
        float HorizontalDelta { set; }
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
        void Align(float deltaTime);
    }
}
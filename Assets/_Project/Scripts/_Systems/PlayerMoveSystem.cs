using CookRun.Core;
using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerMoveSystem : AStandartMovementSystem<PlayerMoveSystemData, IMove>, IPlayerMoveSystem
    {
        private float _acceleration = 0.0f;

        public PlayerMoveSystem(PlayerMoveSystemData systemData, IMove moveData) : base(systemData, moveData)
        { }

        public float HorizontalDelta { set; private get; }

        public override void Accelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(deltaTime / _systemData.accelerationTime);

        public override void Decelerate(float deltaTime) =>
            ApplyChangeMaxSpeedPercentage(-(deltaTime / _systemData.decelerationTime));

        protected override void PerformMovement(float deltaTime)
        {
            MoveForward();
            MoveHorizontal();
            _modelData.ApplyChangePosition(_delta.Value);
        }

        private void MoveForward() =>
            _delta.Z = _systemData.speedForwardMax * _acceleration;

        private void MoveHorizontal() =>
            _delta.X = _systemData.speedHorizontalMax * _acceleration * HorizontalDelta;

        private void ApplyChangeMaxSpeedPercentage(float value) =>
            _acceleration = Mathf.Clamp(_acceleration + value, 0.0f, 1.0f);
    }

    public interface IPlayerMoveSystem : IMoveSystem, IUpdatable
    {
        float HorizontalDelta { set; }
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
    }
}
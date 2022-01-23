using CookRun.Core;
using CookRun.Model;
using CookRun.Utility;
using UnityEngine;

namespace CookRun.Systems
{
    public abstract class AStandartMovementSystem<T, U> : AStandartSystem<T, U>, IStandartMovementSystem
        where T : ISystemData
        where U : ITransformableData
    {
        protected Vector3Variable _delta = null;

        public AStandartMovementSystem(T systemData, U modelData) : base(systemData, modelData)
        {
            _delta = new Vector3Variable(Vector3.zero);
        }

        public abstract void Accelerate(float deltaTime);

        public abstract void Decelerate(float deltaTime);

        public virtual void UpdateLocal(float deltaTime)
        {
            PerformMovement();
        }

        protected abstract void PerformMovement();
    }

    public interface IStandartMovementSystem : IUpdatable
    {
        void Accelerate(float deltaTime);
        void Decelerate(float deltaTime);
    }
}
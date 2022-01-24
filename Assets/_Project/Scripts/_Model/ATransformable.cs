using System;
using UnityEngine;
using CookRun.Utility;

namespace CookRun.Model
{
    public interface IConfigurableSystem<T> where T : IConfigData
    {

    }

    public abstract class ATransformable : IModel, IMove, IRotate
    {
        protected ObservableVector3 _position = null;
        protected ObservableVector3 _rotation = null;

        public ATransformable()
        {
            _position = new ObservableVector3(Vector3.zero);
            _rotation = new ObservableVector3(Vector3.zero);

            _position.ValueChanged += OnPositionChanged;
            _rotation.ValueChanged += OnRotationChanged;
        }

        public Vector3 Position => _position.Value;
        public Vector3 Rotataion => _rotation.Value;

        public event Action Moved;
        public event Action Rotated;
        public event Action Destroying;

        protected virtual void OnPositionChanged() => Moved?.Invoke();
        protected virtual void OnRotationChanged() => Rotated?.Invoke();

        public void ApplyChangePosition(Vector3 position)
        {
            _position.Value += position;
        }

        public void ApplyChangeRotation(Vector3 rotation)
        {
            _rotation.Value += rotation;
        }

        public void SetPosition(Vector3 position)
        {
            _position.Value = position;
        }

        public void SetRotation(Vector3 rotation)
        {
            _rotation.Value = rotation;
        }

        public void ApplyChangeRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            _rotation.Value = new Vector3(x, y, z);
        }

        public virtual void Destroy()
        {
            Destroying?.Invoke();
            _position.ValueChanged -= OnPositionChanged;
            _rotation.ValueChanged -= OnRotationChanged;
        }
    }
}
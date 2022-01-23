using System;
using UnityEngine;

namespace CookRun.Model
{
    public interface IModel
    {
        event Action Destroying;
        void Destroy();
    }

    public interface IModelData
    { }

    public interface ITransformableData : IModelData
    { }

    public interface IMove : ITransformableData
    {
        Vector3 Position { get; }
        event Action Moved;
        void SetPosition(Vector3 position);
        void ApplyChangePosition(Vector3 position);
    }

    public interface IRotate : ITransformableData
    {
        Vector3 Rotataion { get; }
        // Quaternion Rotataion { get; }
        event Action Rotated;
        void SetRotation(Vector3 rotation);
        void ApplyChangeRotation(Vector3 rotation);
        void ApplyChangeRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f);
    }
}
using System;
using UnityEngine;

namespace CookRun.View
{
    public interface IView
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        void SetPosition(Vector3 position);
        // void SetPosition(float x = 0.0f, float y = 0.0f, float z = 0.0f);
        void SetRotation(Quaternion rotation);
        // void SetRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f);
        void SetRotation(Vector3 rotation);
        // void SetRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f);
    }

    public interface ITriggerable
    {
        event Action<Collider> OnTriggerEnter;
    }

    public interface ICollisionable
    {
        event Action<Collision> OnCollisionEnter;
    }

    public interface IRaycastable
    {
        event Action<RaycastHit> OnRaycastHit;
    }
}
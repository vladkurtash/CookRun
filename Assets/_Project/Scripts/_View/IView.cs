using System;
using UnityEngine;
using CookRun.Model;

namespace CookRun.View
{
    public interface IView
    {
        void Setup(IConfigData configData);
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        void SetPosition(Vector3 position);
        // void SetPosition(float x = 0.0f, float y = 0.0f, float z = 0.0f);
        void SetRotation(Quaternion rotation);
        // void SetRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f);
        void SetRotation(Vector3 rotation);
        // void SetRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f);
        void Destroy();
    }

    public interface ITriggerable
    {
        event Action<Collider> TriggerEnter;
    }

    public interface ICollisionable
    {
        event Action<Collision> CollisionEnter;
    }

    public interface IRaycastable
    {
        event Action<RaycastHit> RaycastHit;
    }
}
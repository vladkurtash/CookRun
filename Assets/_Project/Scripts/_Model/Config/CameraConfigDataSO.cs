using System;
using UnityEngine;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "CameraConfigData", menuName = "Config/CameraConfigData")]
    public class CameraConfigDataSO : ConfigDataSO<CameraConfigData>
    {
        public CameraConfigDataSO(CameraConfigData data) : base(data)
        { }
    }

    [Serializable]
    public class CameraConfigData : IConfigData
    {
        [SerializeField] private Alignment _alignment;
        [SerializeField] private Follow _follow;
        public Alignment Alignment => _alignment;
        public Follow Follow => _follow;
    }

    [Serializable]
    public class Alignment
    {
        public Vector3 positionOffset = Vector3.zero;
        public Vector3 targetRotation = Vector3.zero;
        [Tooltip("Degrees per second")]
        public float rotationSpeed = 0.0f;
        [Tooltip("Units per second")]
        public float movementSpeed = 0.0f;
    }

    [Serializable]
    public class Follow
    {
        [Tooltip("Units per second")]
        public float movementSpeed = 0.0f;
        public Vector3 positionOffset = Vector3.zero;
        public Vector3 rotation = Vector3.zero;
        [Tooltip("Degrees per second")]
        public float rotationSpeed = 0.0f;
    }
}
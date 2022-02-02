using UnityEngine;
using System;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerRotateSystemData", menuName = "Config/PlayerRotateSystemData")]
    public class PlayerRotateSystemDataSO : ConfigDataSO<PlayerRotateSystemData>
    {
        public PlayerRotateSystemDataSO(PlayerRotateSystemData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerRotateSystemData : IConfigData
    {
        public float defaultYThreshold = 60.0f;
        public float rotateSpeedMax = 1.0f;
        public float alignmentTime = 1.0f;
        public float accelerationTime = 1.0f;
        public float decelerationTime = 1.0f;
    }
}
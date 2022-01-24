using UnityEngine;
using System;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerMoveSystemData", menuName = "Config/PlayerMoveSystemData")]
    public class PlayerMoveSystemDataSO : ConfigDataSO<PlayerMoveSystemData>
    {
        public PlayerMoveSystemDataSO(PlayerMoveSystemData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerMoveSystemData : IConfigData
    {
        public float speedForwardMax = 1.0f;
        public float speedHorizontalMax = 1.0f;
        public float accelerationTime = 1.0f;
        public float decelerationTime = 1.0f;
    }
}
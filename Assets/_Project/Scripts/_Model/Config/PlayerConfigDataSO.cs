using System;
using UnityEngine;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerConfigData", menuName = "Config/PlayerConfigData")]
    public class PlayerConfigDataSO : ConfigDataSO<PlayerConfigData>
    {
        public PlayerConfigDataSO(PlayerConfigData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerConfigData : IConfigData
    {
        public Vector2 horizontalPositionThreshold = Vector2.zero;
        public Vector2 horizontalRotationThreshold = Vector2.zero;
    }
}
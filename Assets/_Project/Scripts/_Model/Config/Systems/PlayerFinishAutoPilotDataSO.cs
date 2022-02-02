using UnityEngine;
using System;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerFinishAutoPilotData", menuName = "Config/PlayerFinishAutoPilotData")]
    public class PlayerFinishAutoPilotDataSO : ConfigDataSO<PlayerFinishAutoPilotData>
    {
        public PlayerFinishAutoPilotDataSO(PlayerFinishAutoPilotData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerFinishAutoPilotData : IConfigData
    {
        public float speedForwardMax = 1.0f;
        public float speedHorizontalMax = 1.0f;
        public float rotationSpeed = 1.0f;
    }
}
using UnityEngine;
using System;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerSoundSystemData", menuName = "Config/PlayerSoundSystemData")]
    public class PlayerSoundSystemDataSO : ConfigDataSO<PlayerSoundSystemData>
    {
        public PlayerSoundSystemDataSO(PlayerSoundSystemData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerSoundSystemData : IConfigData
    {
        public AudioClip[] swingClips = null;
        public float pitch = 1.0f;
        public float volume = 1.0f;
    }
}
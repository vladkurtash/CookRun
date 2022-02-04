using System;
using UnityEngine;

namespace CookRun.Model
{
    [CreateAssetMenu(fileName = "PlayerAnimationSystemData", menuName = "Config/PlayerAnimationSystemData")]
    public class PlayerAnimationSystemDataSO : ConfigDataSO<PlayerAnimationSystemData>
    {
        public PlayerAnimationSystemDataSO(PlayerAnimationSystemData data) : base(data)
        { }
    }

    [Serializable]
    public class PlayerAnimationSystemData : IConfigData
    {
        [SerializeField] private PlayerAnimatorParameters _parameters;
        public PlayerAnimatorParameters Parameters => _parameters;

        public void Setup()
        {
            _parameters.HashParameters();
        }
    }

    [Serializable]
    public class PlayerAnimatorParameters
    {
        [SerializeField] public string idleString = "";
        [SerializeField] public string runString = "";
        [SerializeField] public string hitString = "";
        [SerializeField] public string dieString = "";
        [SerializeField] public string danceString = "";

        [HideInInspector] public int idleHash = 0;
        [HideInInspector] public int runHash = 0;
        [HideInInspector] public int hitHash = 0;
        [HideInInspector] public int dieHash = 0;
        [HideInInspector] public int danceHash = 0;

        public void HashParameters()
        {
            idleHash = Animator.StringToHash(idleString);
            runHash = Animator.StringToHash(runString);
            hitHash = Animator.StringToHash(hitString);
            dieHash = Animator.StringToHash(dieString);
            danceHash = Animator.StringToHash(danceString);
        }
    }
}
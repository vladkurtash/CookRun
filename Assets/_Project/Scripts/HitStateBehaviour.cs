using UnityEngine;
using CookRun.Model;
using CookRun.Utility.Audio;

namespace CookRun.AnimationBehaviour
{
    public class HitStateBehaviour : StateMachineBehaviour
    {
        private PlayerSoundSystemData _configData = null;
        private Transform _cameraTransform = null;

        private void Awake()
        {
            _configData = PlayerSoundSystemDataSO.Instance.Data;
            _cameraTransform = Camera.main.transform;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            PlaySwingSound();
        }

        public void PlaySwingSound()
        {
            int randomClipIndex = Random.Range(0, _configData.swingClips.Length - 1);
            AudioClip clipToPlay = _configData.swingClips[randomClipIndex];
            AudioPlayer.PlayClipAtPoint
                (clipToPlay, _cameraTransform.position, _configData.pitch, _configData.volume);
        }
    }
}
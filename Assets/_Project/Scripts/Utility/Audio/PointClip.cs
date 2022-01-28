using System.Collections.Generic;
using UnityEngine;

namespace CookRun.Utility.Audio
{
    public class PointClip : MonoBehaviour
    {
        public static PointClip Create(AudioClip clip, Vector3 position, float pitch = 0.0f, float volume = 1.0f)
        {
            GameObject pointObject = new GameObject();
            pointObject.transform.position = position;
            PointClip pointClip = pointObject.AddComponent<PointClip>();

            pointClip._pitch = pitch;
            pointClip._clip = clip;
            pointClip._volume = volume;

            return pointClip;
        }

        private float _pitch = 0.0f;
        private AudioClip _clip = null;
        private float _volume = 1.0f;

        private void Start()
        {
            AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.pitch = _pitch;
            audioSource.PlayOneShot(_clip, _volume);

            Destroy(this.gameObject, _clip.length / _pitch);
        }
    }
}
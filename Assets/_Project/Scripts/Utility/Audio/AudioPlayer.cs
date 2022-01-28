using UnityEngine;

namespace CookRun.Utility.Audio
{
    public static class AudioPlayer
    {
        public static void PlayClipAtPoint(AudioClip clip, Vector3 position, float pitch = 1.0f, float volume = 1.0f)
        {
            PointClip.Create(clip, position, pitch, volume);
        }
    }
}
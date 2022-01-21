using UnityEngine;

namespace CookRun.ProjectConfig
{
    public class FrameRateConfig : MonoBehaviour
    {
        public void SetFrameRate(int value)
        {
            Application.targetFrameRate = value;  
        }
    }
}
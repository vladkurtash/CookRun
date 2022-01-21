using UnityEngine;
using UnityEditor;

namespace CookRun.ProjectConfig
{
    [CustomEditor(typeof(FrameRateConfig))]
    public class FrameRateConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            FrameRateConfig frameRateConfig = target as FrameRateConfig;
            if (GUILayout.Button("Set Frame Rate to 15"))
                frameRateConfig.SetFrameRate(15);
            if (GUILayout.Button("Set Frame Rate to 30"))
                frameRateConfig.SetFrameRate(30);
            if (GUILayout.Button("Set Frame Rate to 60"))
                frameRateConfig.SetFrameRate(60);
            if (GUILayout.Button("Set Frame Rate to 120"))
                frameRateConfig.SetFrameRate(120);
            if (GUILayout.Button("Set Frame Rate to much as possible"))
                frameRateConfig.SetFrameRate(-1);
        }
    }
}
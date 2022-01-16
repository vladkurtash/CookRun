using UnityEngine;

[ExecuteInEditMode]
public class FixMobileDepth : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
    }
}

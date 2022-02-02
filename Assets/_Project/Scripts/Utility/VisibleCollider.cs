using UnityEngine;

namespace CookRun
{
    public class VisibleCollider : MonoBehaviour
    {
        [SerializeField] private Color32 _color = Color.yellow;
        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        }
    }
}
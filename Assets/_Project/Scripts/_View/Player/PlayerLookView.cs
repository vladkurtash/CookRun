using System;
using UnityEngine;
using CookRun.Model;

namespace CookRun.View
{
    public class PlayerLookView : AView, IRaycastable
    {
        public event Action<RaycastHit> RaycastHit;
        private float sightDistance = 1.0f;

        protected override void Setup()
        {
            base.Setup();
            sightDistance = PlayerConfigDataSO.Instance.Data.sightDistance;
        }

        private void FixedUpdate()
        {
            RaycastHit raycastHit = default;
            bool hit = Physics.BoxCast(transform.position, transform.lossyScale / 2,
                Vector3.forward, out raycastHit, transform.rotation, sightDistance);

            if (hit)
            {
                RaycastHit?.Invoke(raycastHit);
            }
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            bool hit = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.forward,
                out RaycastHit raycastHit, transform.rotation, sightDistance);
            if (hit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, Vector3.forward * raycastHit.distance);
                Gizmos.DrawWireCube(transform.position + Vector3.forward * raycastHit.distance,
                    transform.lossyScale);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, Vector3.forward * sightDistance);
                Gizmos.DrawWireCube(transform.position + Vector3.forward * sightDistance,
                    transform.lossyScale);
            }
        }
#endif
    }
}
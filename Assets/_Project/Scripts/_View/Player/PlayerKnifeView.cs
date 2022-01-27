using System;
using UnityEngine;

namespace CookRun.View
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class PlayerKnifeView : AView, ITriggerable
    {
        public event Action<Collider> TriggerEnter;

        private void Awake()
        {   
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider collider)
        {
            TriggerEnter?.Invoke(collider);
        }

#if UNITY_EDITOR
        public void OnDrawGizmos()
        {
            EzySlice.Plane cuttingPlane = new EzySlice.Plane();
            cuttingPlane.Compute(transform);
            cuttingPlane.OnDebugDraw();
        }
#endif
    }
}
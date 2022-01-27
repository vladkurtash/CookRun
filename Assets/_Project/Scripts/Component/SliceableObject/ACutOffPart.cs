using UnityEngine;

namespace CookRun.Component.SliceableObject
{
    public abstract class ACutOffPart : AComponent
    {
        protected void Awake()
        {
            AddComponents();
        }

        protected abstract void AddComponents();
    }

    public class CutOffPartStatic : ACutOffPart
    {
        protected override void AddComponents()
        { }
    }

    public class CutOffPartDynamic : ACutOffPart
    {
        public void AddForce(Vector3 direction, float force)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }

        protected override void AddComponents()
        {
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
        }
    }
}
using UnityEngine;

namespace CookRun.Component.SliceableObject
{
    public abstract class ACutOffPart<T> : AComponent where T : ACutOffPart<T>
    {
        public static T AddComponent(GameObject gameObject)
        {
            T aCutOffPart = gameObject.AddComponent<T>();
            return aCutOffPart;
        }

        public static T AddComponent<U>(GameObject gameObject) where U : Collider
        {
            T aCutOffPart = gameObject.AddComponent<T>();
            gameObject.AddComponent<U>();

            return aCutOffPart;
        }

        protected void Awake()
        {
            AddComponents();
        }

        protected abstract void AddComponents();
    }

    public class CutOffPartStatic : ACutOffPart<CutOffPartStatic>
    {
        protected override void AddComponents()
        { }
    }

    public class CutOffPartDynamic : ACutOffPart<CutOffPartDynamic>
    {
        public void AddForce(Vector3 direction, float force)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }

        protected override void AddComponents()
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
}
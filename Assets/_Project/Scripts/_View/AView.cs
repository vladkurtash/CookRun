using UnityEngine;

namespace CookRun.View
{
    public abstract class AView : MonoBehaviour, IView
    {
        protected Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            Setup();
        }

        public Vector3 Position => transform.localPosition;
        public Quaternion Rotation => _transform.localRotation;

        public void SetPosition(Vector3 position) =>
            _transform.localPosition = position;

        public void SetRotation(Quaternion rotation) =>
            _transform.localRotation = rotation;

        public void SetRotation(Vector3 rotation) =>
            _transform.localRotation = Quaternion.Euler(rotation);

        protected virtual void Setup()
        {
            _transform = GetComponent<Transform>();
        }

        public virtual void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
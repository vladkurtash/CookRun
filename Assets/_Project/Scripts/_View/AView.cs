using UnityEngine;

namespace CookRun.View
{
    public abstract class AView : MonoBehaviour, IView
    {
        protected Transform _transform;

        private void Awake()
        {
            Setup();
        }

        public Vector3 Position => _transform.localPosition;
        public Quaternion Rotation => _transform.localRotation;

        public void SetPosition(Vector3 position) =>
            _transform.position = position;

        public void SetRotation(Quaternion rotation) =>
            _transform.rotation = rotation;

        public void SetRotation(Vector3 rotation) =>
            _transform.rotation = Quaternion.Euler(rotation);

        protected virtual void Setup()
        {
            _transform = gameObject.GetComponent<Transform>();
        }

        public virtual void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
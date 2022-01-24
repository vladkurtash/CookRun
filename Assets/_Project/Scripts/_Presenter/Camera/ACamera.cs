using UnityEngine;

namespace CookRun.Presenter
{
    public abstract class ACamera : MonoBehaviour
    {
        protected Transform _transform = null;
        protected State _localState = State.Disable;
        protected virtual void Awake()
        {
            _transform = GetComponent<Transform>();
        }
        protected enum State
        {
            Disable,
            Enable
        }

        public void Enable() => _localState = State.Enable;
        public void Disable() => _localState = State.Disable;

        protected virtual void LateUpdate()
        {
            if (_localState == State.Disable)
                return;
        }
    }
}
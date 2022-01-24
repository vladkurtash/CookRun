using UnityEngine;
using CookRun.Model;

namespace CookRun.Presenter
{
    public class CameraPresenter : ACameraFollow<CameraConfigData>
    {
        private Phase _phase = Phase.None;
        [SerializeField] private bool _useInitValues = false;

        private Vector3 _positionOffset = Vector3.zero;
        private Quaternion _followRotation = default;

        protected override void Awake()
        {
            base.Awake();

            _localState = State.Enable;
            _phase = Phase.Follow;

            _positionOffset = _useInitValues ? _transform.position :
                ConfigData.Follow.positionOffset;
            _followRotation = _useInitValues ? _transform.localRotation :
                Quaternion.Euler(ConfigData.Follow.rotation);
        }

        private enum Phase
        {
            None,
            Follow,
            Align
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();

            if (_phase == Phase.Follow) Follow();
            else if (_phase == Phase.Align) Align();
        }

        private void Follow() =>
            SetCameraTransform
            (
                _positionOffset,
                _followRotation,
                ConfigData.Follow.movementSpeed,
                ConfigData.Follow.rotationSpeed
            );

        private void Align() =>
            SetCameraTransform
            (
                ConfigData.Alignment.positionOffset,
                Quaternion.Euler(ConfigData.Alignment.targetRotation),
                ConfigData.Alignment.movementSpeed,
                ConfigData.Alignment.rotationSpeed
            );

        private void SetCameraTransform
            (Vector3 positionOffset, Quaternion targetRotation, float movementSpeed, float rotationSpeed)
        {
            Vector3 position = GetPosition(positionOffset, movementSpeed);
            Quaternion rotation = GetRotation(targetRotation, rotationSpeed);

            _transform.SetPositionAndRotation(position, rotation);
        }

        private Vector3 GetPosition(Vector3 positionOffset, float movementSpeed)
        {
            var desiredPosition = Target.position + positionOffset;
            var smoothedPosition =
                Vector3.Lerp(_transform.position, desiredPosition, movementSpeed * Time.deltaTime);

            return smoothedPosition;
        }

        private Quaternion GetRotation(Quaternion targetRotation, float rotationSpeed)
        {
            var smoothedRotation =
                Quaternion.Lerp(_transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            return smoothedRotation;
        }
    }

    public abstract class ACameraFollow<T> : ACamera where T : IConfigData
    {
        public Transform Target { get; set; }
        public T ConfigData { get; set; }
    }
}
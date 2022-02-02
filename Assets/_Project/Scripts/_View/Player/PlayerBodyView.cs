using System;
using UnityEngine;

namespace CookRun.View
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerBodyView : AView, ITriggerable
    {
        [SerializeField] private CharacterController _characterController = null;

        public event Action<Collider> TriggerEnter;

        protected override void Setup()
        {
            base.Setup();
            _characterController = GetComponent<CharacterController>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            TriggerEnter?.Invoke(collider);
        }

        public void Rotate(Vector3 rotation)
        {
            _transform.Rotate(rotation - _transform.rotation.eulerAngles);
        }

        public void Move(Vector3 destination)
        {
            Vector3 motion = destination - _transform.position;
            motion.y = 0.0f;
            _characterController.Move(motion);
        }
    }
}
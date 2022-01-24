using System;
using UnityEngine;

namespace CookRun.View
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerRootView : ARootView, IPlayerRootView
    {
        private CharacterController _characterController = null;

        public PlayerLookView PlayerLookView => (PlayerLookView)GetView<PlayerLookView>();
        public PlayerKnifeView PlayerKnifeView => (PlayerKnifeView)GetView<PlayerKnifeView>();

        protected override void Awake()
        {
            base.Awake();
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector3 destination)
        {
            Vector3 motion = destination - _transform.position;
            _characterController.Move(motion);
        }

        public void Rotate(Vector3 rotation)
        {
            _transform.Rotate(rotation - _transform.rotation.eulerAngles);
        }
    }

    public interface IPlayerRootView
    {
        PlayerLookView PlayerLookView { get; }
        PlayerKnifeView PlayerKnifeView { get; }
        void Move(Vector3 motion);
        void Rotate(Vector3 rotation);
    }
}
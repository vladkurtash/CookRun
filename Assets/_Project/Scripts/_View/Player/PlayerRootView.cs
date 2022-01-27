using System;
using UnityEngine;

namespace CookRun.View
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerRootView : ARootView, IPlayerRootView
    {
        [SerializeField] private CharacterController _characterController = null;
        [SerializeField] private Animator _animator = null;

        public PlayerLookView LookView => (PlayerLookView)GetView<PlayerLookView>();
        public PlayerKnifeView KnifeView => (PlayerKnifeView)GetView<PlayerKnifeView>();
        public Animator Animator => _animator;

        protected override void Awake()
        {
            base.Awake();
            _characterController = GetComponent<CharacterController>();
            _animator = _transform.GetComponentInChildren<Animator>();
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
        PlayerLookView LookView { get; }
        PlayerKnifeView KnifeView { get; }
        Animator Animator { get; }
        void Move(Vector3 motion);
        void Rotate(Vector3 rotation);
    }
}
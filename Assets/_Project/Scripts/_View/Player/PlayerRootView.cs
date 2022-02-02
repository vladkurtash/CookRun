using System;
using UnityEngine;

namespace CookRun.View
{
    public class PlayerRootView : ARootView, IPlayerRootView
    {
        [SerializeField] private Animator _animator = null;

        public PlayerLookView LookView => (PlayerLookView)GetView<PlayerLookView>();
        public PlayerKnifeView KnifeView => (PlayerKnifeView)GetView<PlayerKnifeView>();
        public PlayerBodyView BodyView => (PlayerBodyView)GetView<PlayerBodyView>();
        public Animator Animator => _animator;

        protected override void Setup()
        {
            base.Setup();
            _animator = _transform.GetComponentInChildren<Animator>();
        }
    }

    public interface IPlayerRootView
    {
        PlayerLookView LookView { get; }
        PlayerKnifeView KnifeView { get; }
        PlayerBodyView BodyView { get; }
        Animator Animator { get; }
    }
}
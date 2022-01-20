using System;
using UnityEngine;

namespace CookRun.View
{
    public class PlayerRootView : ARootView, IPlayerRootView
    {
        public PlayerLookView PlayerLookView => (PlayerLookView)GetView<PlayerLookView>();
        public PlayerKnifeView PlayerKnifeView => (PlayerKnifeView)GetView<PlayerKnifeView>();
    }

    public interface IPlayerRootView
    {
        PlayerLookView PlayerLookView { get; }
        PlayerKnifeView PlayerKnifeView { get; }
    }
}
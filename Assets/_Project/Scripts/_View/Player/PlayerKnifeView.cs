using System;
using UnityEngine;

namespace CookRun.View
{
    public class PlayerKnifeView : AView, ITriggerable
    {
        public event Action<Collider> OnTriggerEnter;
    }
}
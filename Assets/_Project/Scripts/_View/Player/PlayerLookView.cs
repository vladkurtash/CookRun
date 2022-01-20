using System;
using UnityEngine;

namespace CookRun.View
{
    public class PlayerLookView : AView, IRaycastable
    {
        public event Action<RaycastHit> OnRaycastHit;
    }
}
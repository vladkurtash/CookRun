using UnityEngine;
using CookRun.Systems;

namespace CookRun.Input
{
    public class PlayerInputRouter : IUpdatable
    {
        private readonly ISlidingArea _slidingArea = null;

        public PlayerInputRouter(ISlidingArea moveStick)
        {
            _slidingArea = moveStick;
        }

        public void UpdateLocal(float deltaTime)
        {
            
        }
    }
}
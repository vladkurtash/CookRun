using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public abstract class ASimpleAnimationSystem<T> where T : IConfigData
    {
        protected T _configData = default;
        protected Animator _animator = null;

        protected ASimpleAnimationSystem(T configData, Animator animator)
        {
            _configData = configData;
            _animator = animator;
        }
    }
}
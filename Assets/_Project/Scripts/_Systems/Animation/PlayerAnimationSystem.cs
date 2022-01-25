using CookRun.Model;
using UnityEngine;

namespace CookRun.Systems
{
    public class PlayerAnimationSystem : ASimpleAnimationSystem<PlayerAnimationSystemData>, IPlayerAnimationSystem
    {
        public PlayerAnimationSystem(PlayerAnimationSystemData configData, Animator animator) : base(configData, animator)
        { }

        private void SetBoolState(int state, bool value)
        {
            _animator.SetBool(state, value);
        }

        private void SetTriggerState(int state)
        {
            _animator.SetTrigger(state);
        }

        public void Dance() => SetTriggerState(_configData.Parameters.danceHash);
        public void Die() => SetTriggerState(_configData.Parameters.dieHash);
        public void Hit() => SetTriggerState(_configData.Parameters.hitHash);
        public void Stand()
        {
            SetBoolState(_configData.Parameters.idleHash, true);
            SetBoolState(_configData.Parameters.runHash, false);
        }
        public void Run()
        {
            SetBoolState(_configData.Parameters.runHash, true);
            SetBoolState(_configData.Parameters.idleHash, false);
        }
    }

    public interface IPlayerAnimationSystem : IPlayerAnimationCombat, IPlayerAnimationMovement
    {   
        void Dance();
        void Die();
    }

    public interface IPlayerAnimationCombat
    {
        void Hit();
    }

    public interface IPlayerAnimationMovement
    {
        void Stand();
        void Run();
    }
}
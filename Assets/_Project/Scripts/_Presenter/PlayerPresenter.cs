using CookRun.Model;
using CookRun.Systems;
using CookRun.View;
using CookRun.Core;
using System;

namespace CookRun.Presenter
{
    public class PlayerPresenter : APresenter, IPlayerPresenter
    {   
        private readonly IMovementSystem _movementSystem;

        public PlayerPresenter(IModel model, IRootView view, IMovementSystem movementSystem) : base(model, view)
        {
            _movementSystem = movementSystem;
        }

        public override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }

        public override void UpdateLocal(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void OnMoved()
        {
            throw new NotImplementedException();
        }

        public void OnRotated()
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlayerPresenter : IPresenter, IUpdatable, IDisposable
    {
        void OnEnable();
        void OnDisable();
        void OnMoved();
        void OnRotated();
    }
}
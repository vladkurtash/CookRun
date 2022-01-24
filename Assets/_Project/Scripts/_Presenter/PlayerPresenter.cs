using CookRun.Model;
using CookRun.Systems;
using CookRun.View;
using CookRun.Core;
using System;
using UnityEngine;

namespace CookRun.Presenter
{
    public class PlayerPresenter : APresenter<PlayerModel, PlayerRootView>, IPlayerPresenter
    {
        private readonly IMovementSystem _movementSystem;

        public PlayerPresenter(PlayerModel model, PlayerRootView view, IMovementSystem movementSystem) : base(model, view)
        {
            _movementSystem = movementSystem;
            SyncModelWithView();
        }

        private void SyncModelWithView()
        {
            _model.SetPosition(_view.Position);
            SyncRotation();

            void SyncRotation()
            {
                Vector3 rotation = _view.Rotation.eulerAngles;
                rotation.y = Utility.Vector.GetAngle0360(Vector3.forward, _view.transform.forward, Vector3.up);
                _model.SetRotation(rotation);
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();
            _model.Moved += OnMoved;
            _model.Rotated += OnRotated;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _model.Moved -= OnMoved;
            _model.Rotated -= OnRotated;
        }

        public override void UpdateLocal(float deltaTime)
        {
            _movementSystem.UpdateLocal(deltaTime);
        }

        public void OnMoved()
        {
            _view.Move(_model.Position);
        }

        public void OnRotated()
        {
            _view.Rotate(_model.Rotataion);
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
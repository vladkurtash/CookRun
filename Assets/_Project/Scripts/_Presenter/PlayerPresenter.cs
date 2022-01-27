using CookRun.Model;
using CookRun.Systems;
using CookRun.View;
using CookRun.Core;
using System;
using UnityEngine;
using CookRun.Component.SliceableObject;

namespace CookRun.Presenter
{
    public class PlayerPresenter : APresenter<PlayerModel, PlayerRootView>, IPlayerPresenter
    {
        private readonly IMovementSystem _movementSystem;
        private readonly IPlayerAnimationSystem _animationSystem;

        public PlayerPresenter(PlayerModel model, PlayerRootView view, IMovementSystem movementSystem, IPlayerAnimationSystem animationSystem) : base(model, view)
        {
            _movementSystem = movementSystem;
            _animationSystem = animationSystem;
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
            _movementSystem.Standing += _animationSystem.Stand;
            _movementSystem.Moving += _animationSystem.Run;
            _view.KnifeView.TriggerEnter += OnKnifeTriggerEnterReact;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _model.Moved -= OnMoved;
            _model.Rotated -= OnRotated;
            _movementSystem.Standing -= _animationSystem.Stand;
            _movementSystem.Moving -= _animationSystem.Run;
            _view.KnifeView.TriggerEnter -= OnKnifeTriggerEnterReact;
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

        private void OnKnifeTriggerEnterReact(Collider collider)
        {
            int inputLayer = collider.gameObject.layer;

            if (inputLayer == (int)Layer.Sliceable)
                Slice(collider);
        }

        private void Slice(Collider collider)
        {
            var slicable = collider.gameObject.GetComponent<ISliceable>();
            slicable?.Slice(_view.KnifeView.Position, _view.KnifeView.transform.up);
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
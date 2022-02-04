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
        private readonly IMoveSystem _moveSystem;
        private readonly IRotateSystem _rotateSystem;
        private readonly IPlayerAnimationSystem _animationSystem;
        private readonly IPlayerFinishAutoPilot _finishAutoPilot;
        public event Action RoadFinishEntered;
        public event Action LevelFinishEntered;

        public PlayerPresenter(PlayerModel model, PlayerRootView view, 
            IPlayerAnimationSystem animationSystem, IPlayerFinishAutoPilot finishAutoPilot, 
            IMoveSystem moveSystem, IRotateSystem rotateSystem) : base(model, view)
        {
            _moveSystem = moveSystem;
            _rotateSystem = rotateSystem;
            _animationSystem = animationSystem;
            _finishAutoPilot = finishAutoPilot;
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
            _moveSystem.Standing += _animationSystem.Stand;
            _moveSystem.Moving += _animationSystem.Run;
            _view.LookView.RaycastHit += OnLookRaycastHitReact;
            _view.BodyView.TriggerEnter += OnBodyTriggerEnterReact;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _model.Moved -= OnMoved;
            _model.Rotated -= OnRotated;
            _moveSystem.Standing -= _animationSystem.Stand;
            _moveSystem.Moving -= _animationSystem.Run;
            _view.LookView.RaycastHit -= OnLookRaycastHitReact;
            _view.BodyView.TriggerEnter -= OnBodyTriggerEnterReact;
        }

        public override void UpdateLocal(float deltaTime)
        {
            _moveSystem.UpdateLocal(deltaTime);
            _rotateSystem.UpdateLocal(deltaTime);
            _finishAutoPilot.UpdateLocal(deltaTime);
        }

        public void OnMoved()
        {
            _view.BodyView.Move(_model.Position);
        }

        public void OnRotated()
        {
            _view.BodyView.Rotate(_model.Rotataion);
        }

        private void SliceObject(Collider collider)
        {
            var slicable = collider.gameObject.GetComponent<ISliceable>();
            slicable?.Slice(_view.KnifeView.Position, _view.KnifeView.transform.up);
        }

        private void OnLookRaycastHitReact(RaycastHit raycastHit)
        {
            int inputLayer = raycastHit.collider.gameObject.layer;
            float hitDistance = PlayerConfigDataSO.Instance.Data.hitDistance;

            if (inputLayer == (int)Layer.Sliceable && raycastHit.distance <= hitDistance)
            {
                _animationSystem.Hit();
                if(raycastHit.distance <= hitDistance / 2)
                    SliceObject(raycastHit.collider);
            }
        }

        private void OnBodyTriggerEnterReact(Collider collider)
        {
            if(collider.tag == "RoadFinish")
            {
                RoadFinishEntered?.Invoke();
                _finishAutoPilot.Perform();
            }

            if(collider.tag == "LevelFinish")
            {
                LevelFinishEntered?.Invoke();
                _finishAutoPilot.StopMovementAndTurn180();
                _animationSystem.Dance();
            }
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
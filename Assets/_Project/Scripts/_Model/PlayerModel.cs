using System;
using UnityEngine;
using CookRun.Utility;

namespace CookRun.Model
{
    public class PlayerModel : ATransformable, IPlayerModel
    {
        private readonly PlayerConfigData _configData = null;
        public float HorizontalRotationAxis => _rotation.Y;

        public PlayerModel(PlayerConfigData configData) : base()
        {
            _configData = configData;
        }

        protected override void OnPositionChanged()
        {
            _position.X = Mathf.Clamp(_position.X, _configData.horizontalPositionThreshold.x, _configData.horizontalPositionThreshold.y);
            base.OnPositionChanged();
        }
        
        protected override void OnRotationChanged()
        {
            _rotation.Y = Mathf.Clamp(_rotation.Y, _configData.horizontalRotationThreshold.x, _configData.horizontalRotationThreshold.y);
            base.OnRotationChanged();
        }
    }

    public interface IPlayerModel : IModel, IMove, IPlayerRotate, IConfigurableSystem<PlayerConfigData>
    {

    }
}
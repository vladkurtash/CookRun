using System;
using UnityEngine;
using CookRun.Utility;

namespace CookRun.Model
{
    public class PlayerModel : ATransformable, IPlayerModel
    {
        public PlayerModel(PlayerConfigData configData) : base()
        { }
    }

    public interface IPlayerModel : IModel, IMove, IPlayerRotate, IConfigurableSystem<PlayerConfigData>
    { }
}
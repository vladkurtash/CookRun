using System;
using UnityEngine;
using CookRun.Utility;

namespace CookRun.Model
{
    public class PlayerModel : Transformable, IPlayerModel
    {
        public PlayerModel(ObservableVector3 position, ObservableVector3 rotation) : base(position, rotation)
        {
            
        }
    }

    public interface IPlayerModel : IModel, IMove, IRotate
    {

    }
}
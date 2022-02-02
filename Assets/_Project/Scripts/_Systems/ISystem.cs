using System;
using UnityEngine;
using CookRun.Core;
using CookRun.Model;
using CookRun.Utility;

namespace CookRun.Systems
{
    public interface ISystem
    {
        void Pause();
        void Unpause();
        void Stop();
    }

    public interface IMoveSystem : ISystem, IUpdatable
    {
        event Action Moving;
        event Action Standing;
    }

    public interface IRotateSystem : ISystem, IUpdatable
    {

    }
}
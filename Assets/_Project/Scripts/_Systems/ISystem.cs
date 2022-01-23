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

    public interface IMoveSystem : ISystem
    {

    }

    public interface IRotateSystem : ISystem
    {

    }
}
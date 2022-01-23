using CookRun.Model;

namespace CookRun.Systems
{
    public abstract class AStandartSystem<T, U> : ISystem
        where T : ISystemData
        where U : IModelData
    {
        protected readonly T _systemData = default;
        protected readonly U _modelData = default;
        protected State _localState = default;

        public AStandartSystem(T systemData, U modelData)
        {
            _systemData = systemData;
            _modelData = modelData;
            _localState = State.Perform;
        }

        protected enum State
        {
            Perform,
            Pause,
            Stop
        }

        public void Pause() => _localState = State.Pause;
        public void Unpause() => _localState = State.Perform;
        public void Stop() => _localState = State.Stop;
    }
}
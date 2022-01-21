using CookRun.Core;

namespace CookRun.Input
{
    public interface IInputRouter : IUpdatable
    {
        void OnEnable();
        void OnDisable();
    }
}
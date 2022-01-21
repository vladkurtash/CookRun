namespace CookRun.View
{
    public interface IRootView
    {
        IView[] Views { get; }
        void Destroy();
    }
}
namespace CookRun.Component
{
    public class InteractiveObject : AComponent
    {

    }

    public interface IDamageable
    {
        bool Alive { get; }
        void TakeDamage(float amout);
        void Kill();
    }

    public interface IDamaging
    {
        void Damage();
    }

    public interface ISoundable
    {
        void MakeSound();
    }
}
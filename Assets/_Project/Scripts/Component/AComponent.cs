using UnityEngine;
using UnityEngine.Events;

namespace CookRun.Component
{
    public abstract class AComponent : MonoBehaviour, IComponent
    {
        protected virtual void OnDisable()
        {
            Destroy();
        }

        protected virtual void Destroy()
        {
            Destroy(this.gameObject);
        }
    }

    public class AResponsable
    {
        [SerializeField] public UnityEvent Response;

        public void Raise()
        {
            Response?.Invoke();
        }
    }

    public interface IComponent
    {
        
    }
}
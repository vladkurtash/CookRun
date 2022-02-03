using System;
using UnityEngine;

namespace CookRun.Presenter.GUI
{
    public abstract class AGUIPresenter : MonoBehaviour
    {
        public abstract void Show(Action action);

        public virtual void Hide() =>
            gameObject.SetActive(false);
    }
}
using System;
using UnityEngine;
using CookRun.Input;

namespace CookRun.Presenter.GUI
{
    public class MainMenuWindowPresenter : AGUIPresenter
    {
        [SerializeField] private SlidingArea slidingArea;

        public override void Show(Action onStartClick)
        {
            slidingArea.PointerDown += () => onStartClick();
            slidingArea.PointerDown += Hide;

            gameObject.SetActive(true);
        }
    }
}
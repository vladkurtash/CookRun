using System;
using UnityEngine;
using CookRun.Input;
using UnityEngine.UI;

namespace CookRun.Presenter.GUI
{
    public class InGameWindowPresenter : AGUIPresenter
    {
        [SerializeField] private Button restartButton;

        public override void Show(Action onRestartClick)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() => onRestartClick());

            gameObject.SetActive(true);
        }
    }
}
using System;
using UnityEngine;
using CookRun.Input;
using UnityEngine.UI;

namespace CookRun.Presenter.GUI
{
    public class GameCompleteWindowPresenter : AGUIPresenter
    {
        [SerializeField] private Button continueButton;

        public override void Show(Action onContinueClick)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() => onContinueClick());
            gameObject.SetActive(true);
        }
    }
}
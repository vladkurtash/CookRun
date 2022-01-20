using System.Collections.Generic;
using UnityEngine;

namespace CookRun.View
{
    public abstract class ARootView : AView, IRootView
    {
        protected IView[] _views = null;

        public IView[] Views => _views;

        protected virtual void Awake()
        {
            base.Setup();
            Setup();
        }

        protected override void Setup()
        {
            InitChildrenViews();
        }

        protected void InitChildrenViews()
        {
            List<IView> iViews = new List<IView>();
            foreach (var iView in this.gameObject.GetComponentsInChildren<IView>())
            {
                if (!(iView is IRootView))
                    iViews.Add(iView);
            }
            _views = iViews.ToArray();
        }

        protected IView GetView<T>() where T : AView
        {
            foreach (var item in _views)
            {
                if (item is T) return item;
            }

            Debug.LogError($"{typeof(ARootView)}: There is no {typeof(T)}");
            return null;
        }
    }
}
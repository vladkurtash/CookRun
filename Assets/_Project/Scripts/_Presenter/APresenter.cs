using CookRun.Model;
using CookRun.Systems;
using CookRun.View;
using CookRun.Core;
using System;

namespace CookRun.Presenter
{
    public abstract class APresenter<T, U> : IPresenter 
        where T : IModel
        where U : IRootView
    {
        protected readonly T _model;
        protected readonly U _view;
        
        public APresenter(T model, U view)
        {
            _model = model;
            _view = view;
        }

        public virtual void OnEnable()
        {
            _model.Destroying += OnDestroying;
        }

        public virtual void OnDisable()
        {
            _model.Destroying -= OnDestroying;
        }

        public abstract void UpdateLocal(float deltaTime);

        public void Dispose()
        {
            _model.Destroy();
        }

        private void OnDestroying()
        {
            _view.Destroy();
        }
    }
}
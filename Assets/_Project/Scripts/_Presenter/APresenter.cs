using CookRun.Model;
using CookRun.Systems;
using CookRun.View;
using CookRun.Core;
using System;

namespace CookRun.Presenter
{
    public abstract class APresenter : IPresenter
    {
        protected readonly IModel _model;
        protected readonly IRootView _view;
        
        public APresenter(IModel model, IRootView view)
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
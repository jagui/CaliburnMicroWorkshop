using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnLifeCycle.ViewModels
{
    [Export]
    public abstract class TabViewModel : Screen
    {
        public event Action<TabViewModel, string> StateChanged = delegate { };

        protected override void OnInitialize()
        {
            base.OnInitialize();
            StateChanged(this, "Initialized");
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            StateChanged(this, "View Attached");
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            StateChanged(this, "View Loaded");
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            StateChanged(this, "Activate");
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            StateChanged(this, "Deactivate");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using CaliburnLifeCycle.Views;

namespace CaliburnLifeCycle.ViewModels
{
    [Export]
    public class WorkspaceViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly IWindowManager _windowManager;
        private int _count;
        private ITail _tail;

        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<TabViewModel> tabs, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            tabs.Apply(ActivateTab);
        }

        private void ActivateTab(TabViewModel tab)
        {
            tab.DisplayName = String.Format("Tab {0}", _count++);
            tab.StateChanged += LogStateChange;
            ActivateItem(tab);
        }

        private void LogStateChange(TabViewModel tab, String message)
        {
            _tail.Append(String.Format("{0} - {1}", tab.DisplayName, message));
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            var tail = view as ITail;
            _tail = tail ?? new TailNull();
        }

        public void CloseTab(TabViewModel tab)
        {
            DeactivateItem(tab, true);
        }

        public void AddSimple()
        {
            ActivateTab(new SimpleTabViewModel());
        }
        public void AddComplex()
        {
            ActivateTab(new ComplexTabViewModel(_windowManager));
        }
    }
}

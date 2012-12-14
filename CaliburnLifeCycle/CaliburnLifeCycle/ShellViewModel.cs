using Caliburn.Micro;
using CaliburnLifeCycle.ViewModels;

namespace CaliburnLifeCycle
{
    using System.ComponentModel.Composition;

    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        private readonly IWindowManager _windowManager;
        private readonly WorkspaceViewModel _workspace;


        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager,WorkspaceViewModel workspace)
        {
            _windowManager = windowManager;
            _workspace = workspace;
        }

        public void Go()
        {
            _windowManager.ShowWindow(_workspace);
        }
    }
}
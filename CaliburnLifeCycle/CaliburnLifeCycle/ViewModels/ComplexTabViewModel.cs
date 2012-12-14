using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnLifeCycle.ViewModels
{
    [Export(typeof(TabViewModel))]
    public class ComplexTabViewModel : TabViewModel
    {
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public ComplexTabViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }


        public override void CanClose(System.Action<bool> callback)
        {
            var result = _windowManager.ShowDialog(new DialogViewModel("Are you sure you want to close me?"));
            callback(result.Value);
        }
    }
}

using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChildScreenViewModel : Screen
    {
        private readonly IBusyIndicator _busyIndicator;

        [ImportingConstructor]
        public ChildScreenViewModel(IBusyIndicator busyIndicator)
        {
            _busyIndicator = busyIndicator;
        }
    }
}

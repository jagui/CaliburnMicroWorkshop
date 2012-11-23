using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly IBusyIndicator _busyIndicator;
        private readonly ApplicationViewModel _application;

        [ImportingConstructor]
        public ShellViewModel(IBusyIndicator busyIndicator, ApplicationViewModel application)
        {
            _busyIndicator = busyIndicator;
            _application = application;
            Items.AddRange(new object[] { _busyIndicator, _application });
        }

        public IBusyIndicator BusyIndicator
        {
            get { return _busyIndicator; }
        }

        public ApplicationViewModel Application
        {
            get { return _application; }
        }
    }
}

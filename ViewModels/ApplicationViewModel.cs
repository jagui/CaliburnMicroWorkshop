using System.ComponentModel.Composition;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    public class ApplicationViewModel
    {
        private readonly IBusyIndicator _busyIndicator;

        [ImportingConstructor]
        public ApplicationViewModel(IBusyIndicator busyIndicator)
        {
            _busyIndicator = busyIndicator;
        }

        public void Busy()
        {
            _busyIndicator.Start();
        }
    }
}

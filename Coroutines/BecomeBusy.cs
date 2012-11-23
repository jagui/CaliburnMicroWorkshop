using Caliburn.Micro;
using CaliburnMicroWorkshop.ViewModels;
using Action = System.Action;

namespace CaliburnMicroWorkshop.Coroutines
{
    public class BecomeBusy : Result
    {
        private readonly IBusyIndicator _busyIndicator;

        public BecomeBusy(IBusyIndicator busyIndicator)
        {
            _busyIndicator = busyIndicator;
        }

        public override void Execute(ActionExecutionContext context)
        {
            new Action(() => _busyIndicator.Start()).OnUIThread();
            OnCompleted();
        }
    }
}

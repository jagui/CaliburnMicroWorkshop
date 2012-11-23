using Caliburn.Micro;
using CaliburnMicroWorkshop.ViewModels;
using Action = System.Action;

namespace CaliburnMicroWorkshop.Coroutines
{
    public class BecomeIdle : Result
    {
        private readonly IBusyIndicator _busyIndicator;

        public BecomeIdle(IBusyIndicator busyIndicator)
        {
            _busyIndicator = busyIndicator;
        }

        public override void Execute(ActionExecutionContext context)
        {
            new Action(() => _busyIndicator.Stop()).OnUIThread();
            OnCompleted();
        }
    }
}
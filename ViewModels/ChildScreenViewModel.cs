using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using CaliburnMicroWorkshop.Coroutines;

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

        public IEnumerable<IResult> DoSomethingExpensive()
        {
            yield return new BecomeBusy(_busyIndicator);
            yield return new SomethingExpensive();
            yield return new BecomeIdle(_busyIndicator);
        }
    }
}

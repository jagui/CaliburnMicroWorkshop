using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using CaliburnMicroWorkshop.Coroutines;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChildScreenViewModel : Screen, IHandle<Enabled>
    {
        private readonly IBusyIndicator _busyIndicator;
        private readonly IEventAggregator _eventAggregator;
        private bool _canDoSomethingExpensive;

        [ImportingConstructor]
        public ChildScreenViewModel(IBusyIndicator busyIndicator, IEventAggregator eventAggregator)
        {
            _busyIndicator = busyIndicator;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public IEnumerable<IResult> DoSomethingExpensive()
        {
            yield return new BecomeBusy(_busyIndicator);
            yield return new SomethingExpensive();
            yield return new BecomeIdle(_busyIndicator);
        }

        public bool CanDoSomethingExpensive
        {
            get { return _canDoSomethingExpensive; }
            set
            {
                if (value.Equals(_canDoSomethingExpensive)) return;
                _canDoSomethingExpensive = value;
                NotifyOfPropertyChange(() => CanDoSomethingExpensive);
            }
        }

        public void Handle(Enabled message)
        {
            CanDoSomethingExpensive = message.ChildScreen == this;
        }
    }
}

using System;
using System.ComponentModel.Composition;
using System.Threading;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    public class ApplicationViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly ChildScreenViewModel _firstScreen;
        private readonly ChildScreenViewModel _secondScreen;
        private readonly ChildScreenViewModel _thirdScreen;
        private readonly IEventAggregator _eventAggregator;
        private readonly Timer _enableTimer;
        private int _enabledIndex;
        [ImportingConstructor]
        public ApplicationViewModel(ChildScreenViewModel firstScreen, ChildScreenViewModel secondScreen, ChildScreenViewModel thirdScreen, IEventAggregator eventAggregator)
        {
            _firstScreen = firstScreen;
            _firstScreen.DisplayName = "First";
            _secondScreen = secondScreen;
            _secondScreen.DisplayName = "Second";
            _thirdScreen = thirdScreen;
            _eventAggregator = eventAggregator;
            _thirdScreen.DisplayName = "Third";
            Items.AddRange(new[] { _firstScreen, _secondScreen, thirdScreen });
            _enableTimer = new Timer(Callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void Callback(object state)
        {
            _enabledIndex++;
            if (_enabledIndex == 3) _enabledIndex = 0;
            _eventAggregator.Publish(new Enabled((ChildScreenViewModel)Items[_enabledIndex]));
        }
    }
}

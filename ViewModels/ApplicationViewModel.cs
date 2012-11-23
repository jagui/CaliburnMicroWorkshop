using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export]
    public class ApplicationViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly ChildScreenViewModel _firstScreen;
        private readonly ChildScreenViewModel _secondScreen;
        private readonly ChildScreenViewModel _thirdScreen;

        [ImportingConstructor]
        public ApplicationViewModel(ChildScreenViewModel firstScreen, ChildScreenViewModel secondScreen, ChildScreenViewModel thirdScreen)
        {
            _firstScreen = firstScreen;
            _firstScreen.DisplayName = "First";
            _secondScreen = secondScreen;
            _secondScreen.DisplayName = "Second";
            _thirdScreen = thirdScreen;
            _thirdScreen.DisplayName = "Third";
            Items.AddRange(new[] { _firstScreen, _secondScreen, thirdScreen });
        }
    }
}

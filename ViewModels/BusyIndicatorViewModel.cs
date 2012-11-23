using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.ViewModels
{
    [Export(typeof(IBusyIndicator))]
    public class BusyIndicatorViewModel : PropertyChangedBase, IBusyIndicator
    {
        private bool _visible;
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (value.Equals(_visible)) return;
                _visible = value;
                NotifyOfPropertyChange(() => Visible);
            }
        }

        public void Start()
        {
            Visible = true;
        }

        public void Stop()
        {
            Visible = false;
        }
    }
}

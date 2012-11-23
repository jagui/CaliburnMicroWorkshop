namespace CaliburnMicroWorkshop.ViewModels
{
    public class Enabled
    {
        private readonly ChildScreenViewModel _childScreen;

        public Enabled(ChildScreenViewModel childScreen)
        {
            _childScreen = childScreen;
        }

        public ChildScreenViewModel ChildScreen
        {
            get { return _childScreen; }
        }
    }
}
using System.Windows;
using Caliburn.Micro;
using CaliburnLifeCycle.ViewModels;

namespace CaliburnLifeCycle
{
    public class DemoWindowManager : WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = base.EnsureWindow(model, view, isDialog);
            if (model is WorkspaceViewModel)
            {
                window.SizeToContent = SizeToContent.Manual;
                window.Width = 768;
                window.Height = 535;
            }
            return window;
        }
    }
}

using System.ComponentModel.Composition;

namespace CaliburnLifeCycle.ViewModels
{
    [Export(typeof(TabViewModel))]
    public class SimpleTabViewModel : TabViewModel
    {
    }
}
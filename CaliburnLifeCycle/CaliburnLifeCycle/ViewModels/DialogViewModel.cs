using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnLifeCycle.ViewModels
{
    public class DialogViewModel : Screen
    {
        public DialogViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        public void Ok()
        {
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }
    }
}

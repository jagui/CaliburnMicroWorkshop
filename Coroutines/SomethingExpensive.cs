using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaliburnMicroWorkshop.Coroutines
{
    public class SomethingExpensive : Result
    {
        public override void Execute(Caliburn.Micro.ActionExecutionContext context)
        {
            Task.Factory
                .StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(4)))
                .ContinueWith(t => OnCompleted());
        }
    }
}

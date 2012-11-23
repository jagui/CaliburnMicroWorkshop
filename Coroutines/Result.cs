using System;
using Caliburn.Micro;

namespace CaliburnMicroWorkshop.Coroutines
{
    public abstract class Result : IResult
    {
        public virtual void Execute(ActionExecutionContext context)
        {
            OnCompleted();
        }

        protected void OnCompleted()
        {
            OnCompleted(new ResultCompletionEventArgs());
        }

        protected void OnCompleted(ResultCompletionEventArgs resultCompletionEventArgs)
        {
            new System.Action(() =>
                {
                    var tmp = Completed;
                    if (tmp != null) tmp(this, resultCompletionEventArgs);
                }).OnUIThread();
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}
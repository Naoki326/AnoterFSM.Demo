using StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace _6_AdditionalFunction.Nodes
{
    [FSMNode("ExceptionNode")]
    public partial class ExceptionNode : EngineBackendNode
    {
        public override IDisposable Subscribe(IObserver<StateTrackInfo> observer)
        {
            return Disposable.Empty;
        }

        public override IDisposable Subscribe(IObserver<ExecuteTrackInfo> observer)
        {
            return Disposable.Empty;
        }

        public Exception Exception => (Exception)Context.TriggerEvent.EventContext;

        public string LastNode => ExecuterContext.LastNodeName;

        protected override async IAsyncEnumerable<IYieldAction> ExecuteEnumerable()
        {
            Debugger.Launch();
            //Debugger.Break();
            yield return Yield.Next;
            yield break;
        }
    }
}

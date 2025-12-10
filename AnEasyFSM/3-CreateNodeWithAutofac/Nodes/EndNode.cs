using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CreateNodeWithAutofac.Nodes
{
    [FSMNode("End")]
    public partial class EndNode : BaseFSMNode
    {
        protected override async Task ExecuteAsync()
        {
            await Task.Delay(1000, Context.Token);
            Console.WriteLine("FSM End.");
            PublishEvent(FSMEnum.Next);
            return;
        }
    }
}

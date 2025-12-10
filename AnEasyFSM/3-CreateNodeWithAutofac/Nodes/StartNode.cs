using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CreateNodeWithAutofac.Nodes
{
    [FSMNode("Start")]
    public partial class StartNode : BaseFSMNode
    {
        protected override async Task ExecuteAsync()
        {
            Console.WriteLine("FSM Start.");
            await Task.Delay(1000, Context.Token);
            PublishEvent(FSMEnum.Next);
            return;
        }
    }
}

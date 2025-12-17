using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CreateNodeWithAutofac.Nodes
{
    [FSMNode("DoSth")]
    public partial class DoSthNode : AsyncEnumFSMNode
    {
        protected override async IAsyncEnumerable<IYieldAction> ExecuteEnumerable()
        {
            Console.WriteLine("Do Something...");
            yield return Yield.Next;
            yield break;
        }
    }
}

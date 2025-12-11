using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_AdditionalFunction.Nodes
{

    [FSMNode("DoSth")]
    public partial class DoSthNode : AsyncEnumFSMNode<MyContext>
    {
        protected override async IAsyncEnumerable<object> ExecuteEnumerable()
        {
            Console.WriteLine("Do Something...");
            yield return Yield.Delay(500);
            Console.WriteLine(Context.Data.Message);
            yield return Yield.Delay(500);
            yield return Yield.Next;
            yield break;
        }
    }
}

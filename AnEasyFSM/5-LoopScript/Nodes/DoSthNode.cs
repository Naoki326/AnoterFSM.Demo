using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_LoopScript.Nodes
{
    public class MyContext
    {
        public string Message { get; set; }
    }

    [FSMNode("DoSth")]
    public partial class DoSthNode : AsyncEnumFSMNode<MyContext>
    {
        protected override async IAsyncEnumerable<IYieldAction> ExecuteEnumerable()
        {
            Console.WriteLine("Do Something...");
            Console.WriteLine(Context.Data.Message);
            yield return Yield.Next;
            yield break;
        }
    }
}

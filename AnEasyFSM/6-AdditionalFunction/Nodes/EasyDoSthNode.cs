using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_AdditionalFunction.Nodes
{

    [FSMNode("EasyDoSth")]
    public partial class EasyDoSthNode : AsyncEnumFSMNode<EasyContext>
    {
        protected override async IAsyncEnumerable<object> ExecuteEnumerable()
        {
            Console.WriteLine("Do Something easy...");
            yield return Yield.Delay(500);

            Random rd = new Random();
            int r = rd.Next(2);
            if(r > 0)
            {
                throw new Exception();
            }

            Console.WriteLine(Context.Data.EasyMessage);
            yield return Yield.Delay(500);
            yield return Yield.Next;
            yield break;
        }
    }
}

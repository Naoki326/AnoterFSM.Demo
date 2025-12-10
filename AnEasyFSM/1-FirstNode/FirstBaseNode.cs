using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_FirstNode
{
    public partial class FirstBaseNode : BaseFSMNode
    {
        protected override async Task ExecuteAsync()
        {
            Console.WriteLine("Hello, World! I'm a base node.");
            await Task.Delay(1000, Context.Token);
            PublishEvent(FSMEnum.Next);
            return;
        }
    }
}

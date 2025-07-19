using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnEasyFSM
{
    [FSMNode("DoSomething", "做些什么", [1], ["NextEvent"], Id = 6)]
    internal class DoSomething : AsyncEnumFSMNode
    {
        private async Task Do()
        {
            try
            {
                Console.WriteLine("Do Something...");
                await Task.Delay(1000, Context.Token);
            }
            catch { }
        }

        protected override async IAsyncEnumerable<object> ExecuteEnumerable()
        {
            await Do();

            yield return Yield.RetryIfFailed(() =>
            {
                Random r = new Random();
                switch(r.Next(0, 2))
                {
                    case 0:
                        Console.WriteLine("throw and retry...");
                        throw new Exception();
                    case 1:
                        Console.WriteLine("no throw...");
                        break;
                }
                return Task.CompletedTask;
            });

            PublishEvent(FSMEnum.Next);
        }
    }
}

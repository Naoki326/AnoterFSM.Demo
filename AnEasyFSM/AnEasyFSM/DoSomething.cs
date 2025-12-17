using StateMachine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnEasyFSM
{
    public enum DebugEnum
    {
        DebugDo,
        DebugStep
    }

    [FSMNode("DoSomething", "做些什么", [1], ["NextEvent"], Id = 6)]
    public partial class DoSomething : AsyncEnumFSMNode<MyData>
    {
        public string SomethingOutPut { get; set; }

        private async Task Do(CancellationToken token)
        {
            try
            {
                Console.WriteLine("Do Something...");
                await Task.Delay(1000, Context.Token);
            }
            catch { }
        }

        public override void InitBeforeStart()
        {
            base.InitBeforeStart();
        }

        protected override async IAsyncEnumerable<IYieldAction> ExecuteEnumerable()
        {
            // 仅捕获OperationCanceled异常
            // 当触发Pause时，Token发出取消请求，此时若Do发出OperationCanceld异常，则进入暂停状态
            // 此时触发继续后，会自动再次执行Do方法
            yield return Yield.RetryIfFailed(async () =>
            {
                await Do(context.Token);
            });

            Console.WriteLine("Before Debug Do");

            yield return Yield.Priority(DebugEnum.DebugDo);

            Console.WriteLine("After Debug Do");

            yield return Yield.Next;

            SomethingOutPut = (Math.Pow(Math.PI, 2)/6).ToString();

            yield break;
        }
    }
}

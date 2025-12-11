using StateMachine;
using System.Numerics;

namespace _6_AdditionalFunction.Nodes
{

    [FSMNode("EasyGroup")]
    public partial class EasyGroup
        : GroupNode<MyContext, EasyContext>
    {
        public override void InitBeforeStart()
        {
            StartName = "EasyDth";
            EndEvent = "LoopEnd";
            base.InitBeforeStart();
        }

        protected override async IAsyncEnumerable<object> ExecuteEnumerable()
        {
            ContextData = new EasyContext() { EasyMessage = "Context changed." };

            // 开启子状态机，执行单个工件
            await foreach (var item in base.ExecuteEnumerable())
            {
                yield return item;
            }
        }
    }

}

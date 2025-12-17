using StateMachine;

namespace _1_FirstNode
{
    public partial class FirstAsyncNode : AsyncEnumFSMNode
    {
        protected override async IAsyncEnumerable<IYieldAction> ExecuteEnumerable()
        {
            await Task.Yield();
            Console.WriteLine("Hello, World! I'm a async node.");
            yield return Yield.Delay(1000);
            yield return Yield.Next;
            yield break;
        }
    }
}

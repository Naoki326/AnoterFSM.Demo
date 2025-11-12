namespace StateMachine
{
    [FSMNode("Start", "启动节点", [1], ["NextEvent"], Id = 0)]
    public partial class StartNode : AsyncEnumFSMNode
    {

        protected override async IAsyncEnumerable<object> ExecuteEnumerable()
        {
            yield return Yield.None;
            try
            {
                Console.WriteLine("do start...");
                await Task.Delay(1000, Context.Token);
            }
            catch (OperationCanceledException)
            { }
            yield return Yield.None;
            PublishEvent(FSMEnum.Next);
        }
    }
}

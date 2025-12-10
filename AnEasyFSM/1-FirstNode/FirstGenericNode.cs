using StateMachine;

namespace _1_FirstNode
{
    public class MyContext
    {
        public string Message { get; set; }
    }
    public partial class FirstGenericNode : EnumFSMNode<MyContext>
    {
        protected override IEnumerable<object> ExecuteEnumerable()
        {
            Console.WriteLine(Context.Data.Message);
            yield return Yield.Delay(1000);
            yield return Yield.Next;
            yield break;
        }
    }
}

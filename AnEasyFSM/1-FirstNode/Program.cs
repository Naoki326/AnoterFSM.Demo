using StateMachine;

namespace _1_FirstNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsyncNode().Wait();
            RunGenericNode().Wait();
        }

        static async Task RunAsyncNode()
        {
            IFSMNode firstNode = new FirstAsyncNode()
            {
                Context = new FSMNodeContext()
            };
            await firstNode.CreateNewAsync();
            await firstNode.RunAsync();
        }

        static async Task RunGenericNode()
        {
            IFSMNode firstNode = new FirstGenericNode()
            {
                Context = new FSMNodeContext<MyContext>()
                {
                    Data = new MyContext() { Message = "Hello, World! I'm a generic context node." }
                }
            };
            await firstNode.CreateNewAsync();
            await firstNode.RunAsync();
            
        }
    }
}

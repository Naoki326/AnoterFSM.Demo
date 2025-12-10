using StateMachine;

namespace _2_ConnectNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFSMNodeFactory nodeFactory = new FSMNodeFactory();
            EasyScript easyScript = EasyScript.Create(nodeFactory);
            Console.WriteLine(easyScript.Engine.ToString());
            RunANode(easyScript).Wait();

        }

        static async Task RunANode(EasyScript easyScript)
        {
            IFSMNode firstNode = easyScript.Dth;
            firstNode.Context = new FSMNodeContext();
            await firstNode.CreateNewAsync();
            await firstNode.RunAsync();
        }
    }
}

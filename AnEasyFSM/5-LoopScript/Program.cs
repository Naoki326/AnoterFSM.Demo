using _5_LoopScript.Nodes;
using Autofac;
using StateMachine;
using System.Reflection;

namespace _5_LoopScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //注册Module
            builder.RegisterAssemblyModules([Assembly.GetExecutingAssembly()]);
            // 注册一个AutofacNodeFactory为单例，构造FSMEngine时可选该对象为参数
            builder.RegisterType<AutofacNodeFactory>().As<IFSMNodeFactory>().SingleInstance();
            var container = builder.Build();

            var easyScript = EasyScript.Create(container.Resolve<IFSMNodeFactory>());

            Execute(easyScript.Engine).Wait();
        }

        static async Task Execute(FSMEngine engine)
        {
            var executor = new FSMExecutor(engine[(ScriptNode)"Start"], engine[(ScriptEvent)"EndEvent"]);

            IObservable<StateTrackInfo> stateObservable = executor;
            stateObservable.Subscribe(stateTrackInfo =>
            {
                //if (stateTrackInfo.IsEnter)
                //    Console.WriteLine($"Track: from {stateTrackInfo.PrevStateName} to {stateTrackInfo.StateName}, Triggerred by {stateTrackInfo.EventName}.");
                //else
                //    Console.WriteLine($"Track: {stateTrackInfo.StateName} leave.");
            });
            IObservable<ExecuteTrackInfo> executeObservable = executor;
            executeObservable.Subscribe(exeTrackInfo =>
            {
                Console.WriteLine($"Execute State: ${exeTrackInfo.CurrentState}.");
            });

            var exeContext = new MyContext() { Message = "Do right things." };
            await executor.RestartAsync(exeContext, true);
            await executor.ExecutorTask;
        }
    }
}

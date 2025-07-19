// See https://aka.ms/new-console-template for more information

// 下面采用两种方式来定义状态机
// 1. 脚本（默认）
#define Script
// 2. 流式API（需要把上面的注释，并打开下面的注释）
// #define FluentAPI

using AnEasyFSM;
using Autofac;
using StateMachine;
using System.Reflection;

var builder = new ContainerBuilder();
//注册Module
Assembly demoNodesAssembly = Assembly.Load("DemoNodes");
builder.RegisterAssemblyModules([Assembly.GetExecutingAssembly(), demoNodesAssembly]);
// 注册一个AutofacNodeFactory为单例，构造FSMEngine时可选该对象为参数
builder.RegisterType<AutofacNodeFactory>().As<IFSMNodeFactory>().SingleInstance();
var container = builder.Build();

#if Script
var engine = new FSMEngine(container.Resolve<IFSMNodeFactory>());
engine.CreateStateMachine(
"""
    def Start(Start)
    {
        1 -> Start2DoEvent;
    }
    Start2DoEvent -> Start to Do;

    def Do(DoSomething)
    {
        1 -> Do2EndEvent;
    }
    Do2EndEvent -> Do to End;

    def End(End)
    {
        1 -> EndEvent;
    }
"""
    );

#endif

#if FluentAPI
var engine = FSMEngineBuilder.Create()
    .ConfigureNodeFactory(container.Resolve<IFSMNodeFactory>())
    .ConfigureFSMDefine(build =>
    {
        build
            .AddNode<StartNode>(DemoState.Start, build =>
            {
                build.SetEventBinding(FSMEnum.Next, DemoEvent.Start2DoEvent);
            })
            .AddNode<DoSomething>(DemoState.Do, build =>
            {
                build.SetEventBinding(FSMEnum.Next, DemoEvent.Do2EndEvent);
            })
            .AddNode<EndNode>(DemoState.End, build =>
            {
                build.SetEventBinding(FSMEnum.Next, DemoEvent.EndEvent);
            })
            .AddConnection(DemoEvent.Start2DoEvent, DemoState.Start, DemoState.Do)
            .AddConnection(DemoEvent.Do2EndEvent, DemoState.Do, DemoState.End)
            ;
    })
    .Build();
#endif

var executor = new FSMExecutor(engine[(ScriptNode)DemoState.Start], engine[(ScriptEvent)DemoEvent.EndEvent]);

Console.WriteLine("Start...");
await executor.RestartAsync();

await Task.Delay(1000);
await executor.PauseAsync();
executor.Continue();

// 等待执行完
await executor.ExecutorTask;

Console.WriteLine("Complete...");
Console.ReadLine();

public enum DemoState
{
    Start,
    Do,
    End,
}

public enum DemoEvent
{
    Start2DoEvent,
    Do2EndEvent,
    EndEvent,
}

using Autofac;
using StateMachine;
using System.Reflection;

namespace _3_CreateNodeWithAutofac
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

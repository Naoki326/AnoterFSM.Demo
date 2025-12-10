using _2_ConnectNode.Nodes;
using StateMachine;

namespace _2_ConnectNode
{
    internal class FSMNodeFactory : IFSMNodeFactory
    {
        public IFSMNode CreateNode(string name)
        {
            switch (name.ToLowerInvariant())
            {
                case "start":
                    return new StartNode();
                case "end":
                    return new EndNode();
                case "dosth":
                    return new DoSthNode();
                default:
                    throw new KeyNotFoundException();
            }
        }

        public string GetNodeFeatureName(Type type)
        {
            if (type == typeof(StartNode))
            {
                return "start";
            }
            if (type == typeof(EndNode))
            {
                return "end";
            }
            if (type == typeof(DoSthNode))
            {
                return "dosth";
            }
            throw new KeyNotFoundException();
        }

        public Type GetNodeType(string name)
        {
            //switch (name.ToLowerInvariant())
            //{
            //    case "start":
            //        return typeof(StartNode);
            //    case "end":
            //        return typeof(EndNode);
            //    case "dosth":
            //        return typeof(DoSthNode);
            //    default:
            //        throw new KeyNotFoundException();
            //}
            throw new NotImplementedException();
        }
    }
}

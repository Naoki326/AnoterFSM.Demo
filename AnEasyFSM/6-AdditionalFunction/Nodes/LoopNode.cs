using StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_AdditionalFunction.Nodes
{
    [FSMNode("Loop")]
    public partial class LoopNode : EnumFSMNode<EasyContext>
    {
        private IEnumerator<int>? _loopEnumerator;
        public override void InitBeforeStart()
        {
            _loopEnumerator = null;
            base.InitBeforeStart();
        }

        protected override IEnumerable ExecuteEnumerable()
        {
            yield return Yield.Delay(1000);
            if (_loopEnumerator is null/* || other initloop condition*/)
            {
                _loopEnumerator = Enumerable.Range(1, 10).GetEnumerator();
            }
            if (!_loopEnumerator.MoveNext())
            {
                _loopEnumerator = null;
                yield return Yield.Break;
                yield break;
            }
            else
            {
                Context.Data.EasyMessage = $"Current output: {_loopEnumerator.Current}.";
                yield return Yield.Next;
                yield break;
            }
        }
    }
}

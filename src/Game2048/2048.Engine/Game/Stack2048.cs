using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public class Stack2048: Stack<int>
    {
        protected bool _CanAddAndPush = true;

        public Stack2048(int capacity):base(capacity)
        {

        }

        public Stack2048(IEnumerable<int> collection):base(collection)
        {

        }

        //Since Push method of the Stack<T> class is not virtual , we use shadowing.
        public virtual void SpecialPush2048(int item)
        {
            if ((this.Count > 0) && this._CanAddAndPush && (item == this.Peek()))
                AddAndPush(item, this.Pop());
            else
                SinglePush(item);                                          
        }

        protected void AddAndPush(int a, int b)
        {
            base.Push(a+b);
            this._CanAddAndPush = false;
        }

        protected void SinglePush(int a)
        {
            base.Push(a);
            this._CanAddAndPush = true;
        }
    }
}

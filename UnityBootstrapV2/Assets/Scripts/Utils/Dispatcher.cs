using Assets.Scripts.Interfaces.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    public class Dispatcher : IDispatcher
    {
        private List<Action> pending = new List<Action>();

        public Dispatcher()
        {
        }

        public void Invoke(Action fn)
        {
            lock (this.pending)
            {
                this.pending.Add(fn);
            }
        }

        public void InvokePending()
        {
            if (this.pending.Count == 0)
            {
                return;
            }

            lock (this.pending)
            {
                var collection = new List<Action>(this.pending);
                this.pending.Clear();
                foreach (var action in collection)
                {
                    action();
                }
            }
        }
    }

}

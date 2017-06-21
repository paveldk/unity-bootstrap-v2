using System;

namespace Assets.Scripts.Interfaces.Utils
{
    public interface IDispatcher
    {
        void Invoke(Action fn);
        void InvokePending();
    }
}

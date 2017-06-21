using Assets.Scripts.Interfaces.Utils;
using System;

namespace Assets.Scripts.Interfaces.Controllers.Base
{
    public interface IController<D, V> : IDisposable
    {
        IContext<D, V> Context { get; }
        void Subscribe();
        void Start();
        bool Enabled { get; set; }
    }
}

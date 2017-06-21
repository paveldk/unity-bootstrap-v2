using Assets.Scripts.Interfaces.Controllers.Base;
using Assets.Scripts.Interfaces.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers.Base
{
    public abstract class ControllerBase<D, V> : IController<D, V>
    {
        public IContext<D, V> Context { get; private set; }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                this.enabled = value;

                if (value)
                {
                    this.Subscribe();
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        protected virtual bool InitialEnabled
        {
            get { return true; }
        }

        protected bool enabled = true;
        protected IList<IDisposable> observables;
        protected IDispatcher dispatcher;

        public ControllerBase(IContext<D, V> context, IDispatcher dispatcher)
        {
            this.Context = context;
            this.dispatcher = dispatcher;
        }

        public virtual void Subscribe()
        {
            this.observables = new List<IDisposable>();
        }

        public virtual void Start()
        {
            if (this.InitialEnabled)
            {
                this.dispatcher.Invoke(this.Subscribe);
            }
        }

        public void Dispose()
        {
            if (this.observables == null)
            {
                return;
            }

            foreach (var observable in this.observables)
            {
                observable.Dispose();
            }
        }
    }

}

using Assets.Scripts.Interfaces.Controllers.Base;
using Assets.Scripts.Interfaces.Utils;
using System;
using System.Collections.Generic;
using UnityBootstrapV2.Interfaces.Services;

namespace Assets.Scripts.Controllers.Base
{
    public class ControllersGeneratorBase<D, V> : IDisposable
    {
        protected IDispatcher dispatcher;
        protected IGameContext gameContext;

        protected IList<IController<D, V>> controllers;

        public ControllersGeneratorBase(IDispatcher dispatcher, IGameContext gameContext)
        {
            this.dispatcher = dispatcher;
            this.gameContext = gameContext;

            this.controllers = new List<IController<D, V>>();
        }

        public void Start()
        {
            this.AddControllers();
            this.dispatcher.Invoke(this.Subscribe);

            foreach (var controller in this.controllers)
            {
                controller.Start();
            }
        }

        public void Dispose()
        {
            foreach (var item in this.controllers)
            {
                item.Dispose();
            }
        }

        protected virtual void AddControllers()
        {
        }

        protected virtual void Subscribe() { }


        protected void AddControllers(params IController<D, V>[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                this.controllers.Add(list[i]);
            }
        }
    }
}

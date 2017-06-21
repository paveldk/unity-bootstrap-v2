using Adic;
using Assets.Scripts.Interfaces.Utils;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class DispatcherHandler : MonoBehaviour
    {
        [Inject]
        private IDispatcher Dispatcher;

        public void Start()
        {
            this.Inject();
        }

        public void Update()
        {
            this.Dispatcher.InvokePending();
        }
    }
}

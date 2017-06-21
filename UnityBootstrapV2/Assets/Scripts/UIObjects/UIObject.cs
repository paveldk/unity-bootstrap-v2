using Assets.Scripts.Interfaces.UIObjects;
using UnityEngine;

namespace Assets.Scripts.UIObjects
{
    public class UIObject : IUIObject
    {
        public GameObject Main { get; set; }
        public GameObject Container { get; set; }

        public UIObject(GameObject main, GameObject container)
        {
            this.Main = main;
            this.Container = container;
        }
    }
}

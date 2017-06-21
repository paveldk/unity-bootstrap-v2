using Assets.Scripts.Interfaces.UIObjects;
using Assets.Scripts.Utils;
using UnityBootstrapV2.Interfaces.Data;

namespace Assets.Scripts.UIObjects
{
    public class Hero<D, V> : Context<D, V>
        where D : IHeroData
        where V : IUIObject
    {
        public Hero(D data, V view) : base(data, view)
        {
        }
    }
}

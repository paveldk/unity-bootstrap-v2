using UniRx;
using UnityBootstrapV2.Interfaces.Data;

namespace UnityBootstrapV2.Core.Data
{
    public class HeroData : IHeroData
    {
        public ReactiveProperty<float> PositionX { get; set; }
        public ReactiveProperty<float> PositionY { get; set; }

        public HeroData()
        {
            this.PositionX = new ReactiveProperty<float>();
            this.PositionY = new ReactiveProperty<float>();
        }
    }
}

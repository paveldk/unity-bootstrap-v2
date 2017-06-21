using UniRx;

namespace UnityBootstrapV2.Interfaces.Data
{
    public interface IHeroData
    {
        ReactiveProperty<float> PositionX { get; }
        ReactiveProperty<float> PositionY { get; }
    }
}

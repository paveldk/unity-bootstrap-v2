namespace Assets.Scripts.Interfaces.Utils
{
    public interface IContext<D, V>
    {
        D Data { get; }
        V View { get; }
    }
}

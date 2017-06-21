using Assets.Scripts.Interfaces.Utils;

namespace Assets.Scripts.Utils
{
    public class Context<D, V> : IContext<D, V>
    {
        public D Data { get; private set; }
        public V View { get; private set; }

        public Context(D data, V view)
        {
            this.Data = data;
            this.View = view;
        }
    }

}

using UnityBootstrapV2.Interfaces.Data;

namespace UnityBootstrapV2.Core.Data
{
    public class Game : IGame
    {
        public IHeroData HeroData { get; private set; }

        public Game()
        {
            this.HeroData = new HeroData();
        }
    }
}

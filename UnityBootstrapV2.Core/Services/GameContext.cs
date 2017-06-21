using UnityBootstrapV2.Core.Data;
using UnityBootstrapV2.Interfaces.Data;
using UnityBootstrapV2.Interfaces.Services;

namespace UnityBootstrapV2.Core.Services
{
    public class GameContext : IGameContext
    {
        public IGame Game { get; private set; }

        public GameContext()
        {
            this.Game = new Game();
        }
    }
}

using Adic;
using System;
using UnityBootstrapV2.Interfaces.Services;

namespace UnityBootstrapV2.Core.Services
{
    public class HeroService : IHeroService
    {
        [Inject]
        private IGameContext gameContext;

        public void ExecuteAction1()
        {
            // could make a server call and update on response
            this.gameContext.Game.HeroData.PositionX.Value += 1f;
        }

        public void ExecuteAction2()
        {
            this.gameContext.Game.HeroData.PositionY.Value += 1f;
        }
    }
}

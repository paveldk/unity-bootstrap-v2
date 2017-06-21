using Assets.Scripts.Controllers.Base;
using Assets.Scripts.Interfaces.UIObjects;
using Assets.Scripts.Interfaces.Utils;
using UnityBootstrapV2.Interfaces.Data;
using UnityBootstrapV2.Interfaces.Services;

namespace Assets.Scripts.Controllers.Hero
{
    public class HeroControllersGenerator<D, V> : ControllersGeneratorBase<D, V>
        where D: IHeroData
        where V: IUIObject
    {
        protected IContext<D, V> context;
        protected IHeroService heroService;

        public HeroControllersGenerator(IContext<D, V> context, IDispatcher dispatcher, IGameContext gameContext, IHeroService heroService)
            : base(dispatcher, gameContext) {
            this.context = context;
            this.heroService = heroService;

            this.Start();
        }

        protected override void AddControllers()
        {
            base.AddControllers();

            // might assign to local variable and then toggle them with .Enabled = true/false
            this.AddControllers(
                new ClickController<D, V>(this.context, this.dispatcher, this.heroService),
                new MoveController<D, V>(this.context, this.dispatcher)
            );
        }
    }
}

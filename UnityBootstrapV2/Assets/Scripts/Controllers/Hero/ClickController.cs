using Assets.Scripts.Controllers.Base;
using Assets.Scripts.Interfaces.Controllers.Base;
using Assets.Scripts.Interfaces.UIObjects;
using Assets.Scripts.Interfaces.Utils;
using UnityBootstrapV2.Interfaces.Data;
using UniRx;
using UniRx.Triggers;
using UnityBootstrapV2.Interfaces.Services;

namespace Assets.Scripts.Controllers.Hero
{
    public class ClickController<D, V> : ControllerBase<D, V>
        where D : IHeroData
        where V : IUIObject
    {
        private IHeroService heroService;

        public ClickController(IContext<D, V> context, IDispatcher dispatcher, IHeroService heroService) : base(context, dispatcher)
        {
            this.heroService = heroService;
        }

        public override void Subscribe()
        {
            base.Subscribe();

            this.observables.Add(
                this.Context.View.Container.OnMouseDownAsObservable()
                    .Subscribe(x => this.OnMouseDown())
                );
        }

        private void OnMouseDown()
        {
            this.heroService.ExecuteAction1();
        }
    }
}

using Assets.Scripts.Controllers.Base;
using Assets.Scripts.Interfaces.Controllers.Base;
using Assets.Scripts.Interfaces.UIObjects;
using Assets.Scripts.Interfaces.Utils;
using UnityBootstrapV2.Interfaces.Data;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Controllers.Hero
{
    public class MoveController<D, V> : ControllerBase<D, V>
        where D: IHeroData
        where V: IUIObject
    {
        public MoveController(IContext<D, V> context, IDispatcher dispatcher) : base(context, dispatcher) { }

        public override void Subscribe()
        {
            base.Subscribe();

            this.observables.Add(
                this.Context.Data.PositionX
                    .Subscribe(x => this.OnHeroMoveX(x))
                );

            this.observables.Add(
                this.Context.Data.PositionX
                    .Subscribe(x => this.OnHeroMoveY(x))
            );
        }

        private void OnHeroMoveX(float x)
        {
            this.dispatcher.Invoke(() =>
            {
                var position = this.Context.View.Container.transform.position;

                this.Context.View.Container.transform.position = new Vector3(x, position.y, position.z);
            });
        }

        private void OnHeroMoveY(float y)
        {
            this.dispatcher.Invoke(() =>
            {
                var position = this.Context.View.Container.transform.position;

                this.Context.View.Container.transform.position = new Vector3(position.x, y, position.z);
            });
        }
    }
}

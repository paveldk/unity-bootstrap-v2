using Adic;
using Assets.Scripts.Interfaces.Utils;
using Assets.Scripts.Utils;
using UnityBootstrapV2.Core.Services;
using UnityBootstrapV2.Interfaces.Services;

public class Bootstrap : ContextRoot
{
    public override void SetupContainers()
    {
        this.AddContainer<InjectionContainer>()
            .RegisterExtension<UnityBindingContainerExtension>()
            .Bind<IGameContext>().ToSingleton<GameContext>()
            .Bind<IHeroService>().ToSingleton<HeroService>()
            .Bind<PrefabService>().ToGameObject("PrefabService")
            .Bind<IDispatcher>().ToSingleton<Dispatcher>()
            .Bind<IEntityGenerator>().ToSingleton<EntityGenerator>();
    }

    public override void Init()
    {
    }
}

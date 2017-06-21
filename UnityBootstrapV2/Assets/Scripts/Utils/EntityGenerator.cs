using Adic;
using Assets.Scripts.Controllers.Hero;
using Assets.Scripts.Interfaces.Controllers.Base;
using Assets.Scripts.Interfaces.UIObjects;
using Assets.Scripts.Interfaces.Utils;
using Assets.Scripts.UIObjects;
using UnityBootstrapV2.Interfaces.Data;
using UnityBootstrapV2.Interfaces.Services;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class EntityGenerator : IEntityGenerator
    {
        [Inject]
        private IGameContext gameContext;
        [Inject]
        private PrefabService prefabService;
        [Inject]
        private IDispatcher dispatcher;
        [Inject]
        private IHeroService heroService;

        public EntityGenerator()
        {
        }

        [PostConstruct]
        private void GenerateStartingObjects()
        {
            // generally when the 3D object is created it should notify some controllers generator class which should create the controllers for the 3D object 
            // but to keep it simple we will do both of those actions here
            Transform heroObject = Object.Instantiate(this.prefabService.HeroPrefab) as Transform;

            heroObject.position = new Vector3();

            IUIObject view = new UIObject(heroObject.gameObject, heroObject.gameObject);

            IContext<IHeroData, IUIObject> hero = new Hero<IHeroData, IUIObject>(this.gameContext.Game.HeroData, view);

            // could store and later dispose if needed
            new HeroControllersGenerator<IHeroData, IUIObject>(hero, this.dispatcher, this.gameContext, this.heroService);

            // this should be done if executing the scenario in the previous comment
            //this.NewHeroGenerated.OnNext(hero);
        }
    }
}

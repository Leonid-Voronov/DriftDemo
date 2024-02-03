using Logic;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallProgressBindings();
            InstallLogicBindings();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<Game>()
                .To<Game>()
                .AsSingle();

            Container.Bind<GameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();

            Container.Bind<SceneLoader>()
                .To<SceneLoader>()
                .AsSingle();

            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void InstallProgressBindings()
        {
            Container.Bind<ILocalStorageService>()
                .To<LocalStorageService>()
                .AsSingle();

            Container.Bind<ICurrencyService>()
                .To<CurrencyService>()
                .AsSingle();
        }

        private void InstallLogicBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveTrigger>()
                .AsSingle();
        }
    }
}

